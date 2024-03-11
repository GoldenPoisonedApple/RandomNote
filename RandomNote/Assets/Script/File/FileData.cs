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
	/// コンストラクタ
	/// </summary>
	/// <param name="title">タイトル、そのままファイルパスへ</param>
	public FileData (string title) {
		this.title = title;
	}
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="title">タイトル、そのままファイルパスへ</param>
	/// <param name="is_locked">隠しファイルかどうか</param>
	public FileData (string title, bool is_locked) {
		this.title = title;
		this.is_locked = is_locked;
	}

	/// <summary>
	/// 単語群データタイトル
	/// </summary>
	public string title = null;

	/// <summary>
	/// 隠しファイルか
	/// </summary>
	public bool is_locked = false;

	/// <summary>
	/// 単語データ
	/// </summary>
	public List<WordData> wordDatas = new List<WordData>();

	/// <summary>
	/// タグデータ
	/// </summary>
	public TagDataWrapper tagDatas = new TagDataWrapper();

	/// <summary>
	/// データ保存
	/// </summary>
	public void Save()
	{
		FileManager fileManager;
		if (is_locked)
			fileManager = new FileManager(title, FileManager.PathType.HIDDEN_NAME);
		else
			fileManager = new FileManager(title, FileManager.PathType.NAME);
		//シリアライズ
		fileManager.Save(this);
	}


	public object GetFlameDatasController ()
	{
		return new FlameDatasControl<WordData>(ref wordDatas);
	}
}