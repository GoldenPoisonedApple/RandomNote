using UnityEngine;

/// <summary>
/// フレームとして扱うインターフェース
/// </summary>
public interface I_Flame
{
	/// <summary>
	/// フレーム作成
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectData(int flame_num, I_FlameData flameData, I_TagControl tagControl);

	/// <summary>
	/// タグデータ更新
	/// </summary>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectTagUpdate (I_TagControl tagControl);
}
