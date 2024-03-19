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
	public void Reflect(int flame_num, I_FlameData flameData, I_TagControl tagControl);

	/// <summary>
	/// タグデータ更新
	/// </summary>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectTagUpdate (I_TagControl tagControl);

	/// <summary>
	/// 長押しリスナー登録
	/// </summary>
	public void AddListener ();

	/// <summary>
	/// InputFlameに情報を反映
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectInput(int flame_num, I_FlameData flameData, I_TagControl tagControl);
	/// <summary>
	/// フレーム新規作成時
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="tagControl">タグデータ</param>
	public void NewInput(int flame_num, I_TagControl tagControl);

	/// <summary>
	/// フレームデータ取得
	/// </summary>
	/// <returns>フレームデータ</returns>
	public I_FlameData GetFlameData();
}
