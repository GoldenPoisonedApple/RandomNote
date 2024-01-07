using System;
using System.Collections.Generic;

/// <summary>
/// 単語リスト
/// </summary>
[Serializable]
public class TagDataWrapper {
    /// <summary>
    /// 作成時コンストラクタ
    /// </summary>
    public TagDataWrapper () {
        //最初のタグデータ保存
        tagData.Add(new TagData("first", 0, -1, -1, 1, TagData.FIRST));
        end = 1;
        pre_end = 0;
        //最後のタグデータ保存
        tagData.Add(new TagData("first", 0, end, -1, 1, TagData.END));
    }

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
    public List<TagData> tagData = new List<TagData>();

    /// <summary>
    /// タグ追加
    /// </summary>
    /// <param name="tagName">追加するタグの名前</param>
    /// <param name="used_count">使用されている数</param>
    /// <returns>追加したタグの保存場所</returns>
    public int addTag(string tagName, int used_count) {
        if (tagData.Count == end)
        {
            //新しい場所に作る場合
            tagData.Add(new TagData(tagName, end, used_count, pre_end, end + 1, TagData.DATA));
        }
        else
        {
            //タグを消した場所に作る場合
            tagData[end].addData(tagName, end, used_count, pre_end);
        }

        //次データのために
        pre_end = end;
        end = tagData[end].next;

        //追加したタグの保存場所返す
        return pre_end;
    }

    /// <summary>
    /// タグ削除
    /// </summary>
    /// <param name="TagNum">タグの保存場所</param>
    public void deleteTag (int TagNum) {
        try
        {
            //タグ削除
            tagData.RemoveAt(TagNum);

        } catch (Exception e)
        {
            DebugControl.Error(e);
        }
    }
}