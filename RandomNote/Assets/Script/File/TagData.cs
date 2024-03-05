using System;

/// <summary>
/// タグ
/// </summary>
[Serializable]
public class TagData {

	public TagData (string name) {
		this.name = name;
		this.amount = 0;
		this.status = DATA;
	}

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
