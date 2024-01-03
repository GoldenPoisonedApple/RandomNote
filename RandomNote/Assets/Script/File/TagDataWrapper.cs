using System.Collections.Generic;

/// <summary>
/// 単語リスト
/// </summary>
public class TagDataWrapper {

    /// <summary>
    /// 次データ入力タグ保存番号
    /// </summary>
    public int end;

    /// <summary>
    /// ラストデータ入力タグ保存番号
    /// </summary>
    public int pre_end;

    /// <summary>
    /// 単語リストのリスト
    /// </summary>
    public List<TagData> listData = new List<TagData>();
}