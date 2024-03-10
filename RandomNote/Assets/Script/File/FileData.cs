using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ファイルデータ
/// </summary>
[Serializable]
public class FileData : I_FileContent
{
	public FileData (string title) {
		this.title = title;
	}

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
	/// データ保存
	/// </summary>
	public void Save()
	{
		FileManager fileManager = new FileManager(Application.persistentDataPath + "/" + title + ".json");
		//シリアライズ
		fileManager.Save(this);
	}
}