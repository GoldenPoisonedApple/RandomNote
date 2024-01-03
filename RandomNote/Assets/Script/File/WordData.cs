using System.Collections.Generic;

/// <summary>
/// 単語データ
/// </summary>
public class WordData : I_FlameData {

    /// <summary>
    /// 登録番号
    /// </summary>
    public int num;

    /// <summary>
    /// 単語名
    /// </summary>
    public string word;

    /// <summary>
    /// コピー回数
    /// </summary>
    public int count;

    /// <summary>
    /// 評価  0はエラー 1～5
    /// </summary>
    public short star_num;

    /// <summary>
    /// 説明文
    /// </summary>
    public string explain;

    /// <summary>
    /// タグ情報
    /// </summary>
    public List<int> tags = new List<int>();

    /// <summary>
    /// 作成日時
    /// </summary>
    public string entry_date;

    /// <summary>
    /// 更新日時
    /// </summary>
    public string update_date;
}
