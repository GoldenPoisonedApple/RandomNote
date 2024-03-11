using System;
using System.Collections.Generic;
using Codice.CM.Client.Differences;

/// <summary>
/// 単語データ
/// </summary>
public class FlameDatasControl <T>
	//制約(I_FileContentというインターフェースを持っている型のみ)
	where T : I_FlameData
	{
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="flameDatas">参照渡し</param>
	public FlameDatasControl(ref List<T> flameDatas)
	{
		this.flameDatas = flameDatas;
	}

	//検索の簡単化のため
	private int next = 0;
	private List<T> flameDatas;

	/// <summary>
	/// フレームデータ全取得
	/// </summary>
	/// <returns>フレームデータ</returns>
	public List<T> GetDatas () {
		// 参照を渡さないようにコピーを作成し渡す
		return new List<T>(flameDatas);
	}
	/// <summary>
	/// 有効フレームデータ全取得
	/// </summary>
	/// <returns>有効フレームデータ</returns>
	public List<T> GetValidDatas () {
		return flameDatas.FindAll(flame => flame.GetStatus()==I_FlameData.DATA);
	}

	/// <summary>
	/// 有効データ数取得
	/// </summary>
	/// <returns>有効データ数</returns>
	public int GetValidCount () {
		int count = 0;
		foreach (T flameData in flameDatas) {
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
	public int Add (T flameData) {
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
			T T = flameDatas[num];
			if (T.GetStatus() == T.DEL)
				throw new Exception("The Data is already deleted");
			else
				T.SetStatus(T.DEL);
				
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
	public void Update (int num, T flameData) {
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
