using System;
using System.IO;
using UnityEngine;

public class FileManager
{

	/// <summary>
	/// データ読み込み、書き込みするデータファイルパス
	/// </summary>
	private string file_path;

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="file_path">ここで渡したファイルに対して操作を行う</param>
	public FileManager(string file_path)
	{
		this.file_path = file_path;
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