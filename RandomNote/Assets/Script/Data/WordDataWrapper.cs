using System;
using System.Collections.Generic;

/// <summary>
/// Jsonとして扱うデータ　リストを利用するためにクラスでラップ
/// </summary>
[Serializable]
public class WordDataWrapper {
    /// <summary>
    /// ワードデータを入れるリスト
    /// </summary>
    public List<WordData> WordDataList = new List<WordData>();
}