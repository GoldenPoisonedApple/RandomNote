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
	/// フレームコントローラ取得
	/// </summary>
	/// <returns>フレームコントローラの戻り値がえげちいので強引にObject型で</returns>
	public Object GetFlameDatasController ();
}
