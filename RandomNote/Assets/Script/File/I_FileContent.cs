using System;
using System.Collections.Generic;

/// <summary>
/// Jsonとして扱うデータファイル一括管理用
/// </summary>
public interface I_FileContent {

	/// <summary>
	/// データをセーブ
	/// パスは[title].jsonとするためタイトルの重複が許されない
	/// </summary>
	public void Save ();
	

	/// <summary>
	/// フレームデータ全取得
	/// </summary>
	/// <returns>フレームデータ</returns>
	public List<I_FlameData> GetDatas ();

	/// <summary>
	/// 有効フレームデータ全取得
	/// </summary>
	/// <returns>有効フレームデータ</returns>
	public List<I_FlameData> GetValidDatas ();

	/// <summary>
	/// 有効フレームデータ数取得
	/// </summary>
	/// <returns>有効フレームデータ数</returns>
	public int GetValidCount ();

	/// <summary>
	/// フレームデータ追加
	/// </summary>
	/// <param name="flameData">フレームデータ</param>
	/// <returns>追加したindex番号</returns>
	public int Add (I_FlameData flameData);

	/// <summary>
	/// フレームデータ削除
	/// </summary>
	/// <param name="num">削除フレームデータ番号</param>
	public void Del (int num);

	/// <summary>
	/// フレームデータ更新
	/// </summary>
	/// <param name="num">更新フレームデータ番号</param>
	/// <param name="flameData">フレームデータ</param>
	public void Update (int num, I_FlameData flameData);
}
