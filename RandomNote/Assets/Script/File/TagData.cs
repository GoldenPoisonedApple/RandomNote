using System;

/// <summary>
/// タグ
/// </summary>
[Serializable]
public class TagData {

	/// <summary>
	/// タグ保存番号
	///<param name="num">保存番号</param>
	///<param name="name">名前</param>
	/// </summary>
	public TagData (int num, string name) {
		this.num = num;
		this.name = name;
		this.amount = 0;
		this.status = DATA;
	}

	/// <summary>
	/// タグ保存番号
	/// </summary>
	public int num;

	/// <summary>
	/// タグ名
	/// </summary>
	public string name;

	/// <summary>
	/// 使用されている数
	/// </summary>
	public int amount;

	/// <summary>
	/// タグの種類, DATAかDELか
	/// </summary>
	public int status;
	public const int DATA = 1;
	public const int DEL = 3;
}
