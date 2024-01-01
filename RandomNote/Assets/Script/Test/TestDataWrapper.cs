using System;
using System.Collections.Generic;

/// <summary>
/// Jsonとして扱うデータ　リストを利用するためにクラスでラップ
/// </summary>
[Serializable]
public class TestDataWrapper {
    /// <summary>
    /// ペイントデータを入れるリスト
    /// </summary>
    public List<TestData> DataList = new List<TestData>();
}

