using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACT_JuscoBot {
	[Serializable]
	public class BackupSetting {
		public string authFilePath;
		public bool backupStarted;

		public List<BackupFileInfo> fileInfos;

		[NonSerialized]
		public bool isModified;
	}

	[Serializable]
	public class BackupFileInfo {
		public string path;
		public string date;
	}



	///*************************************************************
	/// <summary>
	/// XML形式ファイルアクセス
	/// </summary>
	///*************************************************************
	public class XmlFormat {
		/// <summary>
		/// XMLフォーマットセーブ
		/// </summary>
		/// <param name="data">保存データ</param>
		/// <param name="path">保存ファイルパス</param>
		public static void Save<T>(T data, string path) {
			using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8)) {
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(sw, data);
			}
		}

		/// <summary>
		/// XMLフォーマットロード
		/// </summary>
		/// <param name="path">ロードファイルパス</param>
		/// <returns>ロードデータ</returns>
		public static T Load<T>(string path) where T : class {
			if (!File.Exists(path)) return null; // ファイルが存在しない
			using (StreamReader sr = new StreamReader(path, Encoding.UTF8)) {
				var serializer = new XmlSerializer(typeof(T));
				return serializer.Deserialize(sr) as T;
			}
		}
	}
}
