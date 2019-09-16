using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GoogleAPI {
	public static class GoogleDriveAPI {
		// If modifying these scopes, delete your previously saved credentials
		// at ~/.credentials/drive-dotnet-quickstart.json
		static string[] Scopes = { DriveService.Scope.DriveFile };
		static string ApplicationName = "JuscoBot";

		static UserCredential credential;
		static DriveService service;

		public delegate void LogMessage(string message, bool repeat = false);
		public static LogMessage Log;

		public static GDriveFileInfo folderInfo;

		public static async Task<string> Authentication(string jsonPath, string tokenFolderPath) {
			try {
				credential = await GetUserCredential(jsonPath, tokenFolderPath);
				service = new DriveService(new BaseClientService.Initializer() {
					HttpClientInitializer = credential,
					ApplicationName = ApplicationName,
				});
				return "OK";
			} catch(Exception e) {
				return e.Message;
			}
		}

		static Task<UserCredential> GetUserCredential(string jsonPath, string tokenFolderPath) {
			using (var stream = new System.IO.FileStream(jsonPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
				return GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes,
					"user",
					CancellationToken.None,
					new FileDataStore(tokenFolderPath, true));
			}
		}

		public static async Task<bool> SyncFiles(string rootFolderName, List<GDriveFileInfo> infos, bool check = false) {
			if(!check)
				Log.Invoke("***** バックアップ開始 *****");
			else
				Log.Invoke("***** チェック開始 *****");

			// ルートフォルダ取得
			var rootFolder = await GetFolderIfNotiongCreate(rootFolderName);

			// ファイルチェック
			var needSync = await FileCheck(rootFolder, infos);

			if (check) {
				Log.Invoke("***** チェック終了 *****");
				return needSync;
			}

			// ファイルアップロード
			var newFiles = new List<File>();
			if (needSync) {
				Log.Invoke($"ファイルアップロード中 (0 / { infos.Count })");
				// フォルダ新規作成
				var newFolder = await CreateFolder(DateTime.Now.ToString("yyyyMMddHHmm"), rootFolder.Id);
				foreach (var info in infos) {
					var file = await UploadFile(info.filePath, newFolder.Id);
					if (file == null) return false; // アップロードエラーのため中断
					newFiles.Add(file);
					Log.Invoke($"ファイルアップロード中 ({ newFiles.Count } / { infos.Count })", true);
				}
			} else {
				Log.Invoke("変更されたファイルなし");
			}
			Log.Invoke("***** バックアップ終了 *****");
			return true;
		}

		public static async Task<File> GetFolderIfNotiongCreate(string folderName) {
			var folder = await FindByName(folderName, SearchFilter.FOLDER);
			if (folder == null) folder = await CreateFolder(folderName);
			return folder;
		}

		public static async Task<bool> FileCheck(File rootFolder, List<GDriveFileInfo> infos) {
			Log.Invoke("ファイルチェック開始 - ");
			// サブフォルダ取得
			bool needSync = false;
			var folders = await FindFiles(QL($"'{ rootFolder.Id }' in parents", SearchFilter.FOLDER.ToQuery()), "id, name, createdTime");
			if (folders.Count > 0) {
				// 作成日でソートして一番新しいフォルダを取得
				folders.Sort((a, b) => a.CreatedTime.Value.CompareTo(b.CreatedTime.Value));
				var fileFolder = folders.Last();
				// サブフォルダの作成日を超えているファイルがローカルにあるかチェック
				infos.Sort((a, b) => a.ModifiedDate.CompareTo(b.ModifiedDate));
				var lastFile = infos.Last();
				needSync = (fileFolder.CreatedTime.Value.CompareTo(lastFile.ModifiedDate) < 0);
			} else {
				needSync = true;
			}
			Log.Invoke("ファイルチェック開始 - 完了", true);
			return needSync;
		}

		static List<string> QL(params string[] q) {
			return q.ToList();
		}

		public static async Task<File> FindFile(List<string> queries) {
			var result = await FindFilesCore(queries);
			return (result.Count > 0) ? result[0] : null;
		}

		public static async Task<List<File>> FindFiles(List<string> queries, string fileFields) {
			return await FindFilesCore(queries, $"nextPageToken, files({fileFields})");
		}

		static async Task<List<File>> FindFilesCore(List<string> queries, string fields = "nextPageToken, files(id, name)") {
			try {
				string nextPageToken = null;
				queries.Add("trashed = false");

				do {
					FilesResource.ListRequest request = service.Files.List();
					request.PageToken = nextPageToken;
					request.Q = queries.ToQuery();
					request.Fields = fields;
					var result = await request.ExecuteAsync();
					if (result.Files.Count > 0) return result.Files.ToList();
					nextPageToken = result.NextPageToken;
				} while (!string.IsNullOrEmpty(nextPageToken));
				return new List<File>();
			} catch (Exception e) {
				Log.Invoke($"Find File Error: " + e.Message);
				return new List<File>();
			}
		}

		public static async Task<File> CreateFolder(string name, string parentFolderId = null) {
			File meta = new File();
			meta.Name = name;
			meta.MimeType = "application/vnd.google-apps.folder";
			if(parentFolderId != null) meta.Parents = new List<string> { parentFolderId };
			var request = service.Files.Create(meta);
			request.Fields = "id, name";
			return await request.ExecuteAsync();
		}

		public static async Task<File> UploadFile(string filePath, string parentId) {
			try {
				var meta = new File() {
					Name = System.IO.Path.GetFileName(filePath),
					MimeType = GetMimeType(filePath),
					Parents = new List<string> { parentId }
				};
				using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open)) {
					// 新規追加
					var request = service.Files.Create(meta, stream, GetMimeType(filePath));
					request.Fields = "id, name";
					var result = await request.UploadAsync();
					return request.Body;
				}
			} catch (Exception e) {
				Log?.Invoke("Upload Error - " + filePath + " : " + e.Message);
				return null;
			}
		}

		public static async Task<File> FindByName(string name, SearchFilter filter = SearchFilter.NONE) {
			var queries = new List<string>() { $"name = '{ name }'" };
			if (filter != SearchFilter.NONE) queries.Add(filter.ToQuery());
			return await FindFile(queries);
		}


		private static string GetMimeType(string fileName) {
			string mimeType = "application/unknown";
			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
			if (regKey != null && regKey.GetValue("Content Type") != null)
				mimeType = regKey.GetValue("Content Type").ToString();
			return mimeType;
		}
	}

	public class GDriveFileInfo {
		public string filePath;
		public string fileName => System.IO.Path.GetFileName(filePath);
		public DateTime ModifiedDate => System.IO.File.GetLastWriteTime(filePath);
	}

	public enum SearchFilter {
		/// <summary>フィルターなし</summary>
		NONE,
		/// <summary>フォルダのみ</summary>
		FOLDER,
		/// <summary>ファイルのみ</summary>
		FILE,
	}

	// クエリ参考
	// https://developers.google.com/drive/api/v3/search-files
	// https://developers.google.com/drive/api/v3/reference/query-ref
	internal static class GoogleDriveQueryExt {
		public const string IGNORE_TRASH = "trashed = false";

		static List<string> queries = new List<string> {
			null,
			"mimeType = 'application/vnd.google-apps.folder'", // フォルダのみ
			"mimeType != 'application/vnd.google-apps.folder'", // ファイルのみ
		};

		public static string ToQuery(this SearchFilter type) {
			return queries[(int)type];
		}

		public static string ToQuery(this List<string> queries) {
			//while(queries.Contains("")) queries.Remove("");
			//while (queries.Contains(null)) queries.Remove(null);
			return string.Join(" and ", queries);
		}
	}
}