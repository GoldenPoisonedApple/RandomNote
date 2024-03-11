using System;
using System.Collections.Generic;
using Codice.CM.Client.Differences;

/// <summary>
/// 単語データ
/// </summary>
public class FlameDatasControl : I_FlameDatas {

	//検索の簡単化のため
	private int next = 0;
	private List<I_FlameData> flameDatas;

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="flameDatas">参照渡し</param>
	public FlameDatasControl (ref List<I_FlameData> flameDatas) {
		this.flameDatas = flameDatas;
	}

	/// <summary>
	/// フレームデータ全取得
	/// </summary>
	/// <returns>フレームデータ</returns>
	public List<I_FlameData> GetDatas () {
		// 参照を渡さないようにコピーを作成し渡す
		return new List<I_FlameData>(flameDatas);
	}
	/// <summary>
	/// 有効フレームデータ全取得
	/// </summary>
	/// <returns>有効フレームデータ</returns>
	public List<I_FlameData> GetValidDatas () {
		return flameDatas.FindAll(flame => flame.GetStatus()==I_FlameData.DATA);
	}

	/// <summary>
	/// 有効データ数取得
	/// </summary>
	/// <returns>有効データ数</returns>
	public int GetValidCount () {
		int count = 0;
		foreach (I_FlameData flameData in flameDatas) {
			if (flameData.GetStatus() == I_FlameData.DATA)
				count++;
		}
		return count;
	}

	/// <summary>
	/// データ追加
	/// </summary>
	/// <param name="flameData">データ</param>
	/// <returns>追加したindex番号</returns>
	public int Add (I_FlameData flameData) {
		next = SearchNext(next);
		// 登録番号セット
		flameData.SetNum(next);

		if (next >= flameDatas.Count) {
			flameDatas.Add(flameData);
		} else {
			flameDatas[next] = flameData;
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
			I_FlameData I_FlameData = flameDatas[num];
			if (I_FlameData.GetStatus() == I_FlameData.DEL)
				throw new Exception("The Data is already deleted");
			else
				I_FlameData.SetStatus(I_FlameData.DEL);
				
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
			if (flameDatas[num].GetStatus() == I_FlameData.DEL)
				throw new Exception("The Data is deleted");
			else {
				flameData.SetNum(num);
				flameDatas[num] = flameData;
			}
		}
		catch (Exception) { throw; }
	}


	private int SearchNext (int beginIndex) {
		int index;
		for (index=beginIndex; index<flameDatas.Count; index++) {
			if(flameDatas[index].GetStatus() == I_FlameData.DEL)
				break;
		}
		return index;
	}
}
