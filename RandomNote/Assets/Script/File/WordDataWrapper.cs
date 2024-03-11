using System;
using System.Collections.Generic;
using Codice.CM.Client.Differences;

/// <summary>
/// 単語データ
/// </summary>
[Serializable]
public class WordDataWrapper{
	/// <summary>
	/// 単語データのリスト
	/// </summary>
	public List<WordData> wordDatas = new List<WordData>();
}
