using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 単語ファイル群の情報ファイル
/// </summary>
[Serializable]
public class FileListDataWrapper : I_FileContent, I_FlameDatas
{
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
	/// データ保存
	/// </summary>
	public void Save()
	{
		FileManager fileManager = new FileManager(FILE_NAME, FileManager.PathType.NAME);
		//シリアライズ
		fileManager.Save(this);
	}


	/// <summary>
	/// 単語リストデータ全取得
	/// </summary>
	/// <returns>単語リストデータ</returns>
	public List<I_FlameData> GetFlameDatas () {
		List<I_FlameData> list;
		try
		{
			// List型変換
			list = listDatas.ConvertAll(item => (I_FlameData)item);
		}
		catch (Exception) {	throw; }

		return list;
	}


	/// <summary>
	/// 有効単語リスト数取得
	/// </summary>
	/// <returns>有効単語リスト数取得</returns>
	public int GetFlameCount () {
		int count = 0;
		foreach (FileListData word in listDatas) {
			if (word.status == FileListData.DATA)
				count++;
		}
		return count;
	}

	/// <summary>
	/// 単語リストデータ追加
	/// </summary>
	/// <param name="flameData">単語リストデータ</param>
	/// <returns>追加したindex番号</returns>
	public int Add (I_FlameData flameData) {
		next = SearchNext(next);
		// 登録番号セット
		flameData.SetNum(next);

		if (next >= listDatas.Count) {
			listDatas.Add((FileListData)flameData);
		} else {
			listDatas[next] = (FileListData)flameData;
		}
		next++;

		return next-1;
	}

	/// <summary>
	/// 単語リストデータ削除
	/// </summary>
	/// <param name="num">削除単語リストデータ番号</param>
	public void Del (int num) {
		try
		{
			FileListData FileListData = listDatas[num];
			if (FileListData.status == FileListData.DEL)
				throw new Exception("The Data is already deleted");
			else
				FileListData.status = FileListData.DEL;
				
			if (num < next)
				next = num;
		}
		catch (Exception) {	throw; }
	}

	/// <summary>
	/// 単語リストデータ更新
	/// </summary>
	/// <param name="num">更新単語リストデータ番号</param>
	/// <param name="flameData">単語リストデータ</param>
	public void Update (int num, I_FlameData flameData) {
		try
		{
			if (listDatas[num].status == FileListData.DEL)
				throw new Exception("The Data is deleted");
			else {
				flameData.SetNum(num);
				listDatas[num] = (FileListData)flameData;
			}
		}
		catch (Exception) { throw; }
	}
}