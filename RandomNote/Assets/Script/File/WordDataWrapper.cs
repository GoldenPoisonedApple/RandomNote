using System;
using System.Collections.Generic;
using Codice.CM.Client.Differences;

/// <summary>
/// 単語データ
/// </summary>
[Serializable]
public class WordDataWrapper : I_FlameDatas {

	/// <summary>
	/// 単語データのリスト
	/// </summary>
	public List<WordData> wordDatas = new List<WordData>();

	//検索の簡単化のため
	private int next = 0;

	/// <summary>
	/// ワードデータ全取得
	/// </summary>
	/// <returns>ワードデータ</returns>
	public List<I_FlameData> GetFlameDatas () {
		List<I_FlameData> list;
		try
		{
			// List型変換
			list = wordDatas.ConvertAll(item => (I_FlameData)item);
		}
		catch (Exception) {	throw; }

		return list;
	}


	/// <summary>
	/// 有効ワードワード数取得
	/// </summary>
	/// <returns>有効ワードワード数取得</returns>
	public int GetFlameCount () {
		int count = 0;
		foreach (WordData word in wordDatas) {
			if (word.status == WordData.DATA)
				count++;
		}
		return count;
	}

	/// <summary>
	/// ワードデータ追加
	/// </summary>
	/// <param name="flameData">ワードデータ</param>
	/// <returns>追加したindex番号</returns>
	public int Add (I_FlameData flameData) {
		next = SearchNext(next);
		// 登録番号セット
		flameData.SetNum(next);

		if (next >= wordDatas.Count) {
			wordDatas.Add((WordData)flameData);
		} else {
			wordDatas[next] = (WordData)flameData;
		}
		next++;

		return next-1;
	}

	/// <summary>
	/// ワードデータ削除
	/// </summary>
	/// <param name="num">削除ワードデータ番号</param>
	public void Del (int num) {
		try
		{
			WordData wordData = wordDatas[num];
			if (wordData.status == WordData.DEL)
				throw new Exception("The Data is already deleted");
			else
				wordData.status = WordData.DEL;
				
			if (num < next)
				next = num;
		}
		catch (Exception) {	throw; }
	}

	/// <summary>
	/// ワードデータ更新
	/// </summary>
	/// <param name="num">更新ワードデータ番号</param>
	/// <param name="flameData">ワードデータ</param>
	public void Update (int num, I_FlameData flameData) {
		try
		{
			if (wordDatas[num].status == WordData.DEL)
				throw new Exception("The Data is deleted");
			else {
				flameData.SetNum(num);
				wordDatas[num] = (WordData)flameData;
			}
		}
		catch (Exception) { throw; }
	}


	private int SearchNext (int beginIndex) {
		int index;
		for (index=beginIndex; index<wordDatas.Count; index++) {
			if(wordDatas[index].status == WordData.DEL)
				break;
		}
		return index;
	}
}
