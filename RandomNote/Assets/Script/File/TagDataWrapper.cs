using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// 単語リスト
/// </summary>
[Serializable]
public class TagDataWrapper : I_TagControl
{
	/// <summary>
	/// 単語リストのリスト
	/// </summary>
	public List<TagData> tagDatas = new List<TagData>();


	//検索の簡単化のため
	private int next = 0;

	/// <summary>
	/// タグデータ取得
	/// </summary>
	/// <returns>全てのタグデータ</returns>
	public List<TagData> GetDatas() {
		return tagDatas;
	}

	/// <summary>
	/// タグの名前更新
	/// </summary>
	/// <param name="num">更新先のタグ番号</param>
	/// <param name="name">更新後の名前</param>
	public void UpdateName(int num, string name) {
		try
		{
			TagData tagData = tagDatas[num];
			if (tagData.status == TagData.DEL)
				DebugControl.Error("@TagDataWrapper UpDateName, the tag has already been removed");
			else
				tagData.name = name;
		}
		catch (Exception e)
		{
			DebugControl.Error(e);
    }
	}

	/// <summary>
	/// タグの使われてる数をインクリメント
	/// <param name="num">インクリメントするタグ番号</param>
	/// </summary>
	public void Increment(int num) {
		try
		{
			tagDatas[num].amount++;
		}
		catch (Exception e)
		{
			DebugControl.Error(e);
		}
	}

	/// <summary>
	/// 使われてる数を更新
	/// </summary>
	/// <param name="num">更新先のタグ番号</param>
	/// <param name="amount">更新後の使われてる数</param>
	public void UpdateAmount (int num, int amount) {
		try
		{
			tagDatas[num].amount = amount;
		}
		catch (Exception e)
		{
			DebugControl.Error(e);
		}
	}

	/// <summary>
	/// タグを追加
	/// </summary>
	/// <param name="name">タグの名前</param>
	/// <returns>追加したタグの保存番号</returns>
	public int AddTag(string name) {
		if (next >= tagDatas.Count) {
			tagDatas.Add(new TagData(name));
		} else {
			tagDatas[next] = new TagData(name);
		}
		int tmp = next;
		next = SearchNext(next+1);

		return tmp;
	}

	/// <summary>
	/// タグ削除
	/// </summary>
	/// <param name="num">削除するタグ番号</param>
	public void DelTag(int num) {
		try
		{
			tagDatas[num].status = TagData.DEL;
			if (num < next)
				next = num;
		}
		catch (Exception e)
		{
			DebugControl.Error(e);
		}
	}

	/// <summary>
	/// タグの名前取得
	/// </summary>
	/// <param name="num">取得するタグ番号</param>
	/// <returns>タグの名前</returns>
	public string GetName(int num) {
		string tmp = "エラー";
		try
		{
			tmp = tagDatas[num].name;
		}
		catch (Exception e)
		{
			DebugControl.Error(e);
		}
		return tmp;
	}

	/// <summary>
	/// タグの使われてる数取得
	/// </summary>
	/// <param name="num">取得するタグ番号</param>
	/// <returns>タグの使われてる数</returns>
	public int GetAmount(int num) {
		int tmp = -1;
		try
		{
			tmp = tagDatas[num].amount;
		}
		catch (Exception e)
		{
			DebugControl.Error(e);
		}
		return tmp;
	}

	/// <summary>
	/// 次データ保管場所の検索
	/// </summary>
	/// <param name="beginIndex"></param>
	/// <returns></returns>
	private int SearchNext (int beginIndex) {
		int index;
		for (index=beginIndex; index<tagDatas.Count; index++) {
			if(tagDatas[index].status == TagData.DEL)
				break;
		}
		return index;
	}	
}