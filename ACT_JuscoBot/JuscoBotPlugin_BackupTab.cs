using Advanced_Combat_Tracker;
using GoogleAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ACT_JuscoBot {
	partial class JuscoBotPlugin {

		SettingsSerializer xmlBackupSetting;
		BackupSetting backupSetting;

		bool IsAuthd = false;

		/// <summary>
		/// 認証
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void buttonAuth_Click(object sender, EventArgs e) {
			await GoogleDriveAuth();
		}

		private async Task<bool> GoogleDriveAuth() {

			if (!File.Exists(textCredPath.Text)) {
				Log("Unselected JsonFile");
				return false;
			}
			var path = textCredPath.Text;

			var result = await GoogleDriveAPI.Authentication(path, PathHelper.GoogleDriveTokenPath);
			Log("Google Drive Auth - " + result);

			var files = Directory.GetFiles(PathHelper.GoogleDriveTokenPath);
			backupSettingPanel.Enabled = files.Count() > 0;

			if (backupSetting.authFilePath != path) {
				backupSetting.authFilePath = path;
				SaveBackupSettings();
			}
			IsAuthd = true;

			return true;
		}

		/// <summary>
		/// Credentialsファイル選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCredFileSelect_Click(object sender, EventArgs e) {
			OpenFileDialog fd = new OpenFileDialog();
			fd.Filter = "jsonファイル(*.json)|*json";
			fd.Title = "開くファイルを選択してください";
			fd.InitialDirectory = PathHelper.AppFolderPath;
			if (fd.ShowDialog() == DialogResult.OK) {
				textCredPath.Text = fd.FileName;
			}
		}

		private void buttonAddBackupFile_Click(object sender, EventArgs e) {
			Log("未実装");
		}

		private void columnDeleteMenuStrip_Opened(object sender, EventArgs e) {
			columnDeleteMenuStrip.Items[0].Enabled = (listBackup.SelectedItems.Count > 0);
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) {
			foreach (ListViewItem item in listBackup.SelectedItems) listBackup.Items.Remove(item);
		}

		const string FOLDER_NAME = "Act Setting Backup by JuscoBot";

		/// <summary>
		/// バックアップを開始
		/// </summary>
		/// <param name="paths"></param>
		private async void StartBackupFile() {
			try {
				TabPageBackup.Enabled = false;
				var infos = getGDriveInfos();
				var files = await GoogleDriveAPI.SyncFiles(FOLDER_NAME, infos);
			} catch {
				Log("***** バックアップエラー 終了 *****");
			}
			TabPageBackup.Enabled = true;
		}

		/// <summary>
		/// チェック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void buttonBackupCheck_Click(object sender, EventArgs e) {
			try {
				TabPageBackup.Enabled = false;
				var infos = getGDriveInfos();
				var needSync = await GoogleDriveAPI.SyncFiles(FOLDER_NAME, infos, true);
				Log("ファイル更新" + ((needSync) ? "あり" : "なし"));
			} catch {
				Log("***** バックアップエラー 終了 *****");
			}
			TabPageBackup.Enabled = true;
		}

		private List<GDriveFileInfo> getGDriveInfos() {
			var infos = new List<GDriveFileInfo>();
			foreach (ListViewItem item in listBackup.Items) {
				if (File.Exists(item.Text)) {
					infos.Add(new GDriveFileInfo() { filePath = item.Text });
				} else {
					Log(Path.GetFileName(item.Text) + "は見つからないため無視されます");
				}
			}
			return infos;
		}

		/// <summary>
		/// 設定をロード
		/// </summary>
		private void LoadBackupTabSettings() {
			backupSetting = XmlFormat.Load<BackupSetting>(PathHelper.JuscoBotBackupSettingFile);
			if (backupSetting != null) {
				textCredPath.Text = backupSetting.authFilePath;

				listBackup.Items.Clear();
				foreach (var info in backupSetting.fileInfos) {
					var item = new ListViewItem(info.path, info.date);
					listBackup.Items.Add(item);
				}
			} else {
				backupSetting = new BackupSetting();
			}
		}

		/// <summary>
		/// 設定をセーブ
		/// </summary>
		/// <returns></returns>
		public void SaveBackupSettings() {
			XmlFormat.Save(backupSetting, PathHelper.JuscoBotBackupSettingFile);
		}

		private void buttonBackup_Click(object sender, EventArgs e) {
			backupSetting.backupStarted = true;
			List<BackupFileInfo> infos = new List<BackupFileInfo>();
			foreach (ListViewItem item in listBackup.Items) {
				var info = new BackupFileInfo();
				info.path = item.Text;
				info.date = item.SubItems[0].Text;
				infos.Add(info);
			}
			backupSetting.fileInfos = infos;
			StartBackupFile();
		}

		private void buttonAddAutoBackupFile_Click(object sender, EventArgs e) {
			var prevPaths = new List<string>();
			List<BackupFileInfo> infos = new List<BackupFileInfo>();

			foreach (ListViewItem i in listBackup.Items) prevPaths.Add(i.Text);

			listBackup.Items.Clear();
			List<string> targetFolders = new List<string>() { PathHelper.ActConfigFolderPath, PathHelper.HojorinFolderPath };

			foreach (var path in targetFolders) {
				var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
				foreach (var f in files) {
					if (!f.EndsWith(".config") && !f.EndsWith(".xml")) continue;
					if (f.Contains(@"\Config\Backup\")) continue;

					string[] rows = new string[] { f, "- (未実装)" };
					var item = new ListViewItem(rows);
					listBackup.Items.Add(item);

					var info = new BackupFileInfo();
					info.path = item.Text;
					info.date = item.SubItems[0].Text;
					infos.Add(info);
				}
			}

			foreach (ListViewItem i in listBackup.Items) {
				if (!prevPaths.Contains(i.Text)) {
					backupSetting.fileInfos = infos;
					SaveBackupSettings();
					break;
				}
			}
		}
	}
}
