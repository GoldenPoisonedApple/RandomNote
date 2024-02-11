using System;
using System.Collections.Generic;

/// <summary>
/// ファイルデータ
/// </summary>
[Serializable]
public class FileData : I_FileContent {

    /// <summary>
    /// 単語群データタイトル
    /// </summary>
    public string title;

    /// <summary>
    /// 隠しファイルか
    /// </summary>
    public bool is_locked;

    /// <summary>
    /// 単語データリスト
    /// </summary>
    public List<WordData> wordDatas = new List<WordData>();

    /// <summary>
    /// タグデータ
    /// </summary>
    public TagDataWrapper tagDatas;
}