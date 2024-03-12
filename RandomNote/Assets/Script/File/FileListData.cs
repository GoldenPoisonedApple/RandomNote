using System;

/// <summary>
/// 単語リスト
/// </summary>
[Serializable]
public class FileListData : I_FlameData
{
	/// <summary>
	/// 全入力コンストラクタ
	/// </summary>
	public FileListData(string title, string path, bool is_locked, int word_num, string entry_date, string update_date)
	{
		this.title = title;
		this.path = path;
		this.is_locked = is_locked;
		this.word_num = word_num;
		this.entry_date = entry_date;
		this.update_date = update_date;
		status = I_FlameData.DATA;
	}
	/// <summary>
	/// デバッグ用
	/// </summary>
	public FileListData(int num, string title, string path, bool is_locked, int word_num, string entry_date, string update_date)
	{
		this.num = num;
		this.title = title;
		this.path = path;
		this.is_locked = is_locked;
		this.word_num = word_num;
		this.entry_date = entry_date;
		this.update_date = update_date;
		status = I_FlameData.DATA;
	}

	/// <summary>
	/// 登録番号を取得
	/// </summary>
	/// <returns>登録番号</returns>
	public int GetNum () {
		return num;
	}
	/// <summary>
	/// 保存番号設定
	/// </summary>
	/// <param name="num">保存番号</param>
	public void SetNum(int num)
	{
		this.num = num;
	}
	/// <summary>
	/// ステータス取得
	/// </summary>
	/// <returns>ステータス</returns>
	public int GetStatus () {
		return status;
	}
	/// <summary>
	/// ステータス設定
	/// </summary>
	/// <returns>ステータス</returns>
	public void SetStatus (int status) {
		this.status = status;
	}

	/// <summary>
	/// 保存番号
	/// </summary>
	public int num;

	/// <summary>
	/// タイトル
	/// </summary>
	public string title;

	/// <summary>
	/// データファイルのパス
	/// </summary>
	public string path;

	/// <summary>
	/// 隠しファイルかどうか
	/// </summary>
	public bool is_locked;

	/// <summary>
	/// 単語数
	/// </summary>
	public int word_num;

	/// <summary>
	/// 作成日時
	/// </summary>
	public string entry_date;

	/// <summary>
	/// 更新日時
	/// </summary>
	public string update_date;

	/// <summary>
	/// ステータス
	/// </summary>
	public int status;
}
