using System;

/// <summary>
/// 単語リスト
/// </summary>
[Serializable]
public class FileListData : I_FlameData {
    /// <summary>
    /// 全入力コンストラクタ
    /// </summary>
    public FileListData(string title, string path, bool is_locked, int word_num, string entry_date, string update_date) {
        this.title = title;
        this.path = path;
        this.is_locked = is_locked;
        this.word_num = word_num;
        this.entry_date = entry_date;
        this.update_date = update_date;
    }

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
}
