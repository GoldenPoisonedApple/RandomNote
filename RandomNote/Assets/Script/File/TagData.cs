using System;

/// <summary>
/// タグ
/// </summary>
[Serializable]
public class TagData {

    /// <summary>
    /// タグ新規場所に作成時コンストラクタ
    /// endかfirstにしか使わない
    /// </summary>
    /// <param name="word">タグ名</param>
    /// <param name="num">タグ保存番号</param>
    /// <param name="used_count">使用されている数</param>
    /// <param name="pre">前のタグ保存番号</param>
    /// <param name="next">次のタグ保存番号</param>
    /// <param name="next">タグの種類</param>
    public TagData (string word, int num, int used_count, int pre, int next, int state) {
        this.word = word;
        this.num = num;
        this.used_count = used_count;
        this.pre = pre;
        this.next = next;
        this.state = state;
    }
    /// <summary>
    /// タグデータ追加
    /// </summary>
    /// <param name="word">タグ名</param>
    /// <param name="num">タグ保存番号</param>
    /// <param name="used_count">使用されている数</param>
    public void addData(string word, int num, int used_count) {
        this.word = word;
        this.num = num;
        this.used_count = used_count;
        this.state = DATA;
    }

    /// <summary>
    /// タグ名
    /// </summary>
    public string word;

    /// <summary>
    /// タグ保存番号
    /// </summary>
    public int num;

    /// <summary>
    /// 使用されている数
    /// </summary>
    public int used_count;

    /// <summary>
    /// 前のタグ保存番号
    /// </summary>
    public int pre;

    /// <summary>
    /// 次のタグ保存番号
    /// </summary>
    public int next;

    /// <summary>
    /// タグの種類, FIRSTかENDかDATA
    /// </summary>
    public int state;
    public const int FIRST = 0;
    public const int DATA = 1;
    public const int END = 2;
    public const int DELETE = 3;
}
