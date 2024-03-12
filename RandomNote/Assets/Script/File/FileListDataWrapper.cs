using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 単語ファイル群の情報ファイル
/// </summary>
[Serializable]
public class FileListDataWrapper : I_FileContent
{
	/// <summary>
	/// JsonUtilityでクラスのデータを復元する際引数なしのコンストラクタのみ実行されるらしいので
	/// 復元されるときに代入してほしい値をここに記す
	/// </summary>
	public FileListDataWrapper () {
		flameDatasControl = new FlameDatasControl<FileListData>(ref listDatas);
	}
	public const string FILE_NAME = "_FILE_LIST";

	/// <summary>
	/// 隠しファイルパス単語リスト
	/// </summary>
	public string pass_word;

	/// <summary>
	/// 単語リストのリスト
	/// </summary>
	public List<FileListData> listDatas = new List<FileListData>();


	/// <summary>
	/// コントローラ
	/// </summary>
	private FlameDatasControl<FileListData> flameDatasControl;

	/// <summary>
	/// データ保存
	/// </summary>
	public void Save()
	{
		FileManager fileManager = new FileManager(FILE_NAME, FileManager.PathType.NAME);
		//シリアライズ
		fileManager.Save(this);
	}

	// 以下コンポジション
	public List<I_FlameData> GetDatas () { return flameDatasControl.GetDatas(); }
	public List<I_FlameData> GetValidDatas () { return flameDatasControl.GetValidDatas(); }
	public int GetValidCount () { return flameDatasControl.GetValidCount(); }
	public int Add (I_FlameData flameData) { return flameDatasControl.Add(flameData); }
	public void Del (int num) { flameDatasControl.Del(num); }
	public void Update (int num, I_FlameData flameData) { flameDatasControl.Update(num, flameData); }

	/// <summary>
	/// タグコントローラ取得
	/// タグデータを扱わないためExceptionを返す
	/// </summary>
	/// <returns>タグコントローラ</returns>
	public I_TagControl GetTagControl () {
		throw new Exception("This class is designed without Tag");
	}
}