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
        pre_end = 0;
        end = pre_end + 1;
        //最初のタグデータ保存
        tagData.Add(new TagData("first", pre_end, -1, -1, end, TagData.FIRST));
        //最後のタグデータ保存
        tagData.Add(new TagData("first", end, -1, pre_end, end+1, TagData.END));
    }

    /// <summary>
    /// タグ追加
    /// </summary>
    /// <param name="tagName">追加するタグの名前</param>
    /// <param name="used_count">使用されている数</param>
    /// <returns>追加したタグの保存場所</returns>
    public int addTag(string tagName, int used_count)
    {
        //endタグ作成
        if (tagData[end].state == TagData.END) {
            tagData.Add(new TagData("end", tagData[end].next, -1, end, end+2, TagData.END));
        }
        //タグ追加
        tagData[end].addData(tagName, end, used_count);
        //end設定
        pre_end = end;
        end = tagData[end].next;

        //追加したタグの保存場所返す
        return pre_end;
    }

    /// <summary>
    /// タグ削除
    /// </summary>
    /// <param name="tagNum">タグの保存場所</param>
    public void deleteTag(int tagNum)
    {
        try {
            if (tagNum == pre_end) {
                //end_preのタグ削除
                tagData[pre_end].state = TagData.DELETE;
                end = pre_end;
                pre_end = tagData[end].pre;

            } else {
                //その他のタグ削除
                tagData[tagNum].state = TagData.DELETE;
                tagData[tagData[tagNum].pre].next = tagData[tagNum].next;
                tagData[tagData[tagNum].next].pre = tagData[tagNum].pre;
                //タグ後置
                tagData[tagNum].pre = pre_end;
                tagData[tagNum].next = end;
                tagData[pre_end].next = tagNum;
                tagData[end].pre = tagNum;
                //end設定
                end = tagNum;

            }
        } catch (Exception e) {
            DebugControl.Error(e);
        }
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
}