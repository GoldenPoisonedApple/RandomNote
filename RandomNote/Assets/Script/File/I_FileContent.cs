/// <summary>
/// Jsonとして扱うデータファイル一括管理用
/// </summary>
public interface I_FileContent {	

	/// <summary>
	/// データをセーブ
	/// パスは[title].jsonとするためタイトルの重複が許されない
	/// </summary>
	public void Save ();
}
