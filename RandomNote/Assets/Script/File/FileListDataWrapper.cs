using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 単語ファイル群の情報ファイル
/// </summary>
[Serializable]
public class FileListDataWrapper : I_FileContent
{
	public const string FILE_NAME = "_FILE_LIST";

	/// <summary>
	/// 隠しファイルパスワード
	/// </summary>
	public string pass_word;

	/// <summary>
	/// 単語リストのリスト
	/// </summary>
	public List<I_FlameData> listData = new List<I_FlameData>();

	/// <summary>
	/// データ保存
	/// </summary>
	public void Save()
	{
		FileManager fileManager = new FileManager(FILE_NAME, FileManager.PathType.FILE_NAME);
		//シリアライズ
		fileManager.Save(this);
	}
}