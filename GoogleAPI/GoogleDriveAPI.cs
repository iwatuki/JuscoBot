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

		public delegate void LogMessage(string message);
		public static LogMessage Log;

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

		const string FOLDER_NAME = "Act Setting Backup";

		public static async Task<bool> UploadFile(string filePath) {
			var folder = await FindByName(FOLDER_NAME, SearchFilter.FOLDER);
			if (folder == null) {
				Log?.Invoke("Create a folder");
				folder = await CreateFolder(FOLDER_NAME);
			}

			var meta = new File() {
				Name = System.IO.Path.GetFileName(filePath),
				MimeType = GetMimeType(filePath),
				Parents = new List<string> { folder.Id }
			};
			

			FilesResource.CreateMediaUpload request;
			using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open)) {
				request = service.Files.Create(meta, stream, GetMimeType(filePath));
				request.KeepRevisionForever = true;
				var result = await request.UploadAsync();
				return result.Status == Google.Apis.Upload.UploadStatus.Completed;
			}
		}

		public static async Task<File> FindById(string id, SearchFilter filter = SearchFilter.NONE, bool searchForTrash = false) {
			var query = $"id = '{ id }'";
			query += $" and trashed = { searchForTrash.ToString().ToLower() }";
			query += ((filter != SearchFilter.NONE) ? filter.ToQuery() : null);
			return await FindFile(query); 
		}

		public static async Task<File> FindByName(string name, SearchFilter filter = SearchFilter.NONE, bool searchForTrash = false) {
			var query = $"name = '{ name }'";
			query += $" and trashed = { searchForTrash.ToString().ToLower() }";
			query += ((filter != SearchFilter.NONE) ? filter.ToQuery() : null);
			return await FindFile(query);
		}

		public static async Task<File> FindFile(string query) {
			var result = await FindFiles(query);
			return (result != null) ? result[0] : null;
		}

		public static async Task<IList<File>> FindFiles(string query) {
			string nextPageToken = null;
			do {
				FilesResource.ListRequest request = service.Files.List();
				request.PageToken = nextPageToken;
				request.Q = query;
				request.Fields = "nextPageToken, files(id, name)";
				var result = await request.ExecuteAsync();
				if (result.Files.Count > 0) return result.Files;
				nextPageToken = result.NextPageToken;
			} while (!string.IsNullOrEmpty(nextPageToken));
			return null;
		}

		public static async Task<File> CreateFolder(string name, string parentFolderId = null) {
			File meta = new File();
			meta.Name = name;
			meta.MimeType = "application/vnd.google-apps.folder";
			if(parentFolderId != null) meta.Parents = new List<string> { parentFolderId };
			var request = service.Files.Create(meta);
			request.Fields = "id";
			return await request.ExecuteAsync();
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

	public enum SearchFilter {
		/// <summary>フィルターなし</summary>
		NONE,
		/// <summary>フォルダのみ</summary>
		FOLDER,
		/// <summary>ファイルのみ</summary>
		FILE,
	}

	// フィルター参考
	// https://developers.google.com/drive/api/v3/search-files
	public static class SearchTypeExt {
		static List<string> queries = new List<string> {
			null,
			"mimeType = 'application/vnd.google-apps.folder'", // フォルダのみ
			"mimeType != 'application/vnd.google-apps.folder'", // ファイルのみ
		};

		public static string ToQuery(this SearchFilter type) {
			return " and " + queries[(int)type];
		}
	}
}