using System;
using System.IO;
using System.Collections.Generic;


/// <summary>
/// 単語リスト
/// </summary>
[Serializable]
public class FileListData : I_FlameData
{
	/// <summary>
	/// 全入力コンストラクタ
	/// </summary>
	public FileListData(string title, I_FileContent.FileType type, bool is_locked, int word_num, string entry_date)
	{
		this.title = title;
		this.type = (int)type;
		this.is_locked = is_locked;
		this.word_num = word_num;
		this.entry_date = entry_date;
		update_date = entry_date;
		status = I_FlameData.DATA;
	}
	/// <summary>
	/// デバッグ用
	/// </summary>
	public FileListData(int num, string title, I_FileContent.FileType type, bool is_locked, int word_num, string entry_date, string update_date)
	{
		this.num = num;
		this.title = title;
		this.type = (int)type;
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
	/// タグ情報取得
	/// </summary>
	/// <returns>タグ情報</returns>
	public List<int> GetTags () {
		throw new NotImplementedException();
	}

	/// <summary>
	/// コピー作成用コンストラクタ
	/// </summary>
	private FileListData (int num, string title, int type, bool is_locked, int word_num, string entry_date, string update_date, int status)
	{
		this.num = num;
		this.title = title;
		this.type = type;
		this.is_locked = is_locked;
		this.word_num = word_num;
		this.entry_date = entry_date;
		this.update_date = update_date;
		this.status = status;
	}
	public I_FlameData Clone()
	{
		return new FileListData(num, title, type, is_locked, word_num, entry_date, update_date, status);
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
	/// ファイルのタイプ
	/// </summary>
	public int type;

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
