using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ファイルデータ
/// </summary>
[Serializable]
public class FileData : I_FileContent
{
	/// <summary>
	/// 単語群データタイトル
	/// </summary>
	public string title = null;

	/// <summary>
	/// 隠しファイルか
	/// </summary>
	public bool is_locked;

	/// <summary>
	/// 単語データ
	/// </summary>
	public WordDataWrapper wordDatas = new WordDataWrapper();

	/// <summary>
	/// タグデータ
	/// </summary>
	public TagDataWrapper tagDatas = new TagDataWrapper();

	/// <summary>
	/// ファイルを新規作成
	/// </summary>
	/// <param name="title">作成ファイルタイトル(ファイル名)</param>
	public void CreateNewFile (string title) {
		if (this.title == null) {
			this.title = title;
			Save();
		}
	}

	/// <summary>
	/// データ保存
	/// </summary>
	public void Save()
	{
		FileManager fileManager = new FileManager(Application.persistentDataPath + "/" + title + ".json");
		//シリアライズ
		fileManager.Save(this);
	}
}