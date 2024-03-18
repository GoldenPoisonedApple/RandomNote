using System.Collections.Generic;

/// <summary>
/// タグ操作 どうせTagDataWrapperの具現クラス使うからいらん気がするけど
/// </summary>
public interface I_TagControl {
	/// <summary>
	/// タグデータ取得
	/// </summary>
	/// <returns>全てのタグデータ</returns>
	public List<TagData> GetDatas();
	/// <summary>
	/// 有効なタグデータ取得
	/// </summary>
	/// <returns>全てのタグデータ</returns>
	public List<TagData> GetValidDatas();
	
	/// <summary>
	/// タグの名前更新
	/// </summary>
	/// <param name="num">更新先のタグ番号</param>
	/// <param name="name">更新後の名前</param>
	public void UpdateName(int num, string name);

	/// <summary>
	/// タグの使われてる数をインクリメント
	/// <param name="num">インクリメントするタグ番号</param>
	/// </summary>
	public void Increment(int num);

	/// <summary>
	/// 使われてる数を更新
	/// </summary>
	/// <param name="num">更新先のタグ番号</param>
	/// <param name="amount">更新後の使われてる数</param>
	public void UpdateAmount(int num, int amount);

	/// <summary>
	/// タグを追加
	/// </summary>
	/// <param name="name">タグの名前</param>
	/// <returns>追加したタグの保存番号</returns>
	public int AddTag(string name);	/// <summary>
	/// タグを追加
	/// </summary>
	/// <param name="name">タグの名前</param>
	/// <param name="amount">使われてる数</param>
	/// <returns>追加したタグの保存番号</returns>
	public int AddTag(string name, int amount);

	/// <summary>
	/// タグ削除
	/// </summary>
	/// <param name="num">削除するタグ番号</param>
	public void DelTag(int num);

	/// <summary>
	/// タグの名前取得
	/// </summary>
	/// <param name="num">取得するタグ番号</param>
	/// <returns>タグの名前</returns>
	public string GetName(int num);

	/// <summary>
	/// タグの使われてる数取得
	/// </summary>
	/// <param name="num">取得するタグ番号</param>
	/// <returns>タグの使われてる数</returns>
	public int GetAmount(int num);

	/// <summary>
	/// タグの個数取得
	/// </summary>
	/// <returns>タグの個数</returns>
	public int GetTagCount();
}
