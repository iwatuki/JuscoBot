using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_JuscoBot {
	public static class EnvHelper {
		public static bool StartupIsDebugGUI => (ActGlobals.oFormActMain == null); // TODO: 本当はAppDomainで見たほうがいいかもね？

	}

	public static class PathHelper {
		/// <summary>起動中のExeフォルダパス</summary>
		public static string AppFolderPath => AppDomain.CurrentDomain.BaseDirectory;
		/// <summary>Actのデータフォルダパス</summary>
		public static string ActDataFolderPath => GetActDataPath();
		/// <summary>ActのConfigフォルダパス</summary>
		public static string ActConfigFolderPath => Path.Combine(GetActDataPath(), @"Config");
		/// <summary>Hojorinのデータフォルダパス</summary>
		public static string HojorinFolderPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"anoyetta\ACT");
		/// <summary>GoogleDriveのTokenパス</summary>
		public static string GoogleDriveTokenPath => Path.Combine(JuscoBotSettingFolderPath, @"GoogleDriveToken");

		/// <summary>本アプリの設定フォルダパス</summary>
		public static string JuscoBotSettingFolderPath => Path.Combine(ActDataFolderPath, @"Config\JuscoBot");
		/// <summary>Discord設定ファイルパス</summary>
		public static string JuscoBotDiscordSettingFile => Path.Combine(JuscoBotSettingFolderPath, @"ACT_JuscoBotDiscord.xml");
		/// <summary>Backup設定ファイルパス</summary>
		public static string JuscoBotBackupSettingFile => Path.Combine(JuscoBotSettingFolderPath, @"ACT_JuscoBotBackup.xml");


		/// <summary>%AppData%フォォルダパス</summary>
		static string AppDataPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		static string GetActDataPath() {
			return (!EnvHelper.StartupIsDebugGUI) ? ActGlobals.oFormActMain.AppDataFolder.FullName : Path.Combine(AppDataPath, @"Advanced Combat Tracker");
		}
	}
}
