/// <summary>
/// Jsonとして扱うデータファイル一括管理用
/// </summary>
public interface I_FileContent {

	/// <summary>
	/// ファイルを新規作成
	/// </summary>
	/// <param name="title">作成ファイルタイトル(ファイル名)</param>
	public void CreateNewFile (string title);

	/// <summary>
	/// データをセーブ
	/// パスは[title].jsonとするためタイトルの重複が許されない
	/// </summary>
	public void Save ();
}
