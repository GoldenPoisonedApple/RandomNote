using System;
using System.Collections.Generic;

/// <summary>
/// 単語データ
/// </summary>
[Serializable]
public class WordData : I_FlameData {
    /// <summary>
    /// 新規作成時コンストラクタ
    /// 更新日時は新規作成日時と同じになる
    /// コピー回数は0が初期値として入れられる
    /// </summary>
    /// <param name="num">登録番号</param>
    /// <param name="word">単語名</param>
    /// <param name="star_num">評価</param>
    /// <param name="explain">説明</param>
    /// <param name="tags">タグ</param>
    /// <param name="entry_date">作成日時</param>
    public WordData(int num, string word, short star_num, string explain, List<int> tags, string entry_date)
    {
        this.num = num;
        this.word = word;
        count = 0;
        this.star_num = star_num;
        this.explain = explain;
        this.tags = tags;
        this.entry_date = entry_date;
        this.update_date = entry_date;
    }

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
