/// <summary>
/// 単語リスト
/// </summary>
public class FileListData : I_FlameData {

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
