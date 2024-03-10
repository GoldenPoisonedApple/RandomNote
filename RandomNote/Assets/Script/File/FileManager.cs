using System;
using System.IO;
using UnityEngine;

public class FileManager
{
	/// <summary>
	/// ファイルのパス読み取り形式
	/// </summary>
	public enum PathType
	{
		PATH,
		NAME,
		HIDDEN_NAME,
	};

	/// <summary>
	/// データ読み込み、書き込みするデータファイルパス
	/// </summary>
	private string file_path;

	private const string FOLDER_NAME = "/data/";
	private const string HIDDEN_FOLDER_NAME = "/hidden/";


	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="file_path">ファイルの名前</param>
	/// <param name="type">PathType.PATH : ファイルの絶対パス, PathType.NAME : ファイルの名前, PathType.HIDDEN_NAME : 隠しファイルの名前</param>
	public FileManager(string file_path, PathType type)
	{
		if (type == PathType.PATH)	// 絶対パス
			this.file_path = file_path;

		else if (type == PathType.NAME) {	// 通常ファイル
			string folder_path = Application.persistentDataPath + FOLDER_NAME;
			//もしファイルが無かったら作成する
			if (!Directory.Exists(folder_path))
        Directory.CreateDirectory(folder_path);
			
			this.file_path = folder_path + file_path + ".json";

		} else if (type == PathType.HIDDEN_NAME) {	// 隠しファイル
			string folder_path = Application.persistentDataPath + HIDDEN_FOLDER_NAME;
			//もしファイルが無かったら隠しフォルダを作成する
			if (!Directory.Exists(folder_path)) {
        Directory.CreateDirectory(folder_path);
				// フォルダの属性を取得
				FileAttributes attributes = File.GetAttributes(folder_path);
				// Hidden フラグを追加
				attributes |= FileAttributes.Hidden;
				// フォルダの属性を更新
				File.SetAttributes(folder_path, attributes);
			}
			this.file_path = folder_path + file_path + ".json";

		}
	}

	/// <summary>
	/// 書き込み機能
	/// </summary>
	/// <param name="paintDataWrapper">シリアライズするデータ</param>
	public void Save(I_FileContent fileContent)
	{

		string jsonSerializedData = JsonUtility.ToJson(fileContent);
		//ログ表示
		//Debug.Log(jsonSerializedData);

		//実際にファイル作って書き込む
		using (var sw = new StreamWriter(file_path, false))
		{
			try
			{
				//ファイルに書き込む(上書き)
				sw.Write(jsonSerializedData);
			}
			catch (Exception e) //失敗した時の処理
			{
				throw e;
			}
		}
	}


	/// <summary>
	/// 読み込み
	/// </summary>
	/// <typeparam name="T">読み込みデータ型</typeparam>
	/// <returns>読み込んだデータ</returns>
	public T Load<T>()
			//制約(I_FileContentというインターフェースを持っている型のみ)
			where T : I_FileContent
	{
		T jsonDeserializedData = default;

		try
		{
			//ファイルを読み込む
			using (FileStream fs = new FileStream(file_path, FileMode.Open))
			using (StreamReader sr = new StreamReader(fs))
			{
				string result = sr.ReadToEnd();
				//ログ表示
				//Debug.Log(result);

				//読み込んだJsonを構造体にぶちこむ
				jsonDeserializedData = JsonUtility.FromJson<T>(result);
			}
		}
		catch (Exception e) //失敗した時の処理
		{
			throw e;
		}

		//デシリアライズした構造体を返す
		return jsonDeserializedData;
	}
}