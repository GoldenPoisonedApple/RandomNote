using System;
using System.Collections.Generic;

/// <summary>
/// 単語ファイル群の情報ファイル
/// </summary>
[Serializable]
public class FileListDataWrapper : I_FileContent {

    /// <summary>
    /// 隠しファイルパスワード
    /// </summary>
    public string pass_word;

    /// <summary>
    /// 単語リストのリスト
    /// </summary>
    public List<FileListData> listData = new List<FileListData>();
}