using System;
using System.Collections.Generic;

/// <summary>
/// ワードデータを入れる構造体
/// </summary>
[Serializable]
public class WordData
{
    /// <summary>
    /// 登録番号
    /// </summary>
    public int num;

    /// <summary>
    /// 単語
    /// </summary>
    public string word;

    /// <summary>
    /// 説明
    /// </summary>
    public string explain;

    /// <summary>
    /// 評価
    /// </summary>
    public string star_num;

    /// <summary>
    /// タグ番号
    /// </summary>
    public List<int> tag = new List<int>();
}