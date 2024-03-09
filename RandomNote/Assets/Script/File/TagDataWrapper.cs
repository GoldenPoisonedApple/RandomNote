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
	private bool FIRST_FLAG = true;

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
			if (tagData.status == TagData.DATA)
				tagData.name = name;
			else
				throw new Exception("This tag is deleted");
		}
		catch (Exception)
		{
			throw;
    }
	}

	/// <summary>
	/// タグの使われてる数をインクリメント
	/// <param name="num">インクリメントするタグ番号</param>
	/// </summary>
	public void Increment(int num) {
		try
		{
			TagData tagData = tagDatas[num];
			if (tagData.status == TagData.DATA)
				tagData.amount++;
			else
				throw new Exception("This tag is deleted");
		}
		catch (Exception)
		{
			throw;
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
			TagData tagData = tagDatas[num];
			if (tagData.status == TagData.DATA)
				tagData.amount = amount;
			else
				throw new Exception("This tag is deleted");
		}
		catch (Exception)
		{
			throw;
		}
	}

	/// <summary>
	/// タグを追加
	/// </summary>
	/// <param name="name">タグの名前</param>
	/// <returns>追加したタグの保存番号</returns>
	public int AddTag(string name) {
		if (FIRST_FLAG) {
			FIRST_FLAG = false;
			next = SearchNext(0);
		}
		if (next >= tagDatas.Count) {
			tagDatas.Add(new TagData(next, name));
		} else {
			tagDatas[next] = new TagData(next, name);
		}
		int tmp = next;
		next = SearchNext(next+1);

		return tmp;
	}
	/// <summary>
	/// タグを追加
	/// </summary>
	/// <param name="name">タグの名前</param>
	/// <param name="amount">使われてる数</param>
	/// <returns>追加したタグの保存番号</returns>
	public int AddTag(string name, int amount) {
		int index = AddTag(name);
		UpdateAmount(index, amount);
		
		return index;
	}

	/// <summary>
	/// タグ削除
	/// </summary>
	/// <param name="num">削除するタグ番号</param>
	public void DelTag(int num) {
		try
		{
			TagData tagData = tagDatas[num];
			if (tagData.status == TagData.DATA) {
				tagDatas[num].status = TagData.DEL;
				if (num < next)
					next = num;
			} else
				throw new Exception("This tag is already deleted");
		}
		catch (Exception)
		{
			throw;
		}
	}

	/// <summary>
	/// タグの名前取得
	/// </summary>
	/// <param name="num">取得するタグ番号</param>
	/// <returns>タグの名前</returns>
	public string GetName(int num) {
		string tmp = "ERR";
		try
		{
			TagData tagData = tagDatas[num];
			if (tagData.status == TagData.DATA)
				tmp = tagData.name;
			else
				throw new Exception("This tag is deleted");
		}
		catch (Exception)
		{
			throw;
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
			TagData tagData = tagDatas[num];
			if (tagData.status == TagData.DATA)
				tmp = tagData.amount;
			else
				throw new Exception("This tag is deleted");
		}
		catch (Exception)
		{
			throw;
		}
		return tmp;
	}

	/// <summary>
	/// 存在するタグの個数取得
	/// </summary>
	/// <returns>タグの個数</returns>
	public int GetTagCount() {
		int count = 0;
		foreach (TagData tag in tagDatas) {
			if (tag.status == TagData.DATA)
				count++;
		}
		return count;
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