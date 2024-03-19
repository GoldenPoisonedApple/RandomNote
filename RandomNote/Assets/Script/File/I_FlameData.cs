using System.Collections.Generic;

/// <summary>
/// 書き込みファイル一括管理用
/// </summary>
public interface I_FlameData{
	/// <summary>
	/// データ
	/// </summary>
	public const int DATA = 1;
	/// <summary>
	/// 削除済み
	/// </summary>
	public const int DEL = 0;

	/// <summary>
	/// 登録番号を取得
	/// </summary>
	/// <returns>登録番号</returns>
	public int GetNum ();
	/// <summary>
	/// 登録番号を登録
	/// </summary>
	/// <param name="num">登録番号</param>
	public void SetNum (int num);

	/// <summary>
	/// ステータス取得
	/// </summary>
	/// <returns>ステータス</returns>
	public int GetStatus ();

	/// <summary>
	/// ステータス設定
	/// </summary>
	public void SetStatus (int status);

	/// <summary>
	/// タグ情報取得
	/// </summary>
	/// <returns>タグ情報</returns>
	public List<int> GetTags ();

	/// <summary>
	/// コピー作成
	/// </summary>
	/// <returns>コピー</returns>
	public I_FlameData Clone();
}
