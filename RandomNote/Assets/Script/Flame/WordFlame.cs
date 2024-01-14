using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WordFlame : MonoBehaviour, I_Flame
{

    [SerializeField]
    private Transform flame_prehub;     //フレームプレハブ
    [SerializeField]
    private TMP_Text num_text;     //フレーム番号
    [SerializeField]
    private TMP_Text word_text;     //単語名
    [SerializeField]
    private TMP_Text explain_text;     //説明
    [SerializeField]
    private TMP_Text count_text;     //回数
    [SerializeField]
    private TMP_Text time_text;     //日時
    [SerializeField]
    private Transform[] stars;     //星
    [SerializeField]
    private Transform tag_prehub;     //タグ

    /// <summary>
    /// ワードフレームにデータ反映
    /// </summary>
    /// <param name="flameData">フレームに反映させるデータ</param>
    /// <param name="flame_num">フレーム番号</param>
    public void ReflectData(I_FlameData flameData, int flame_num)
    {
        WordData wordData = (WordData)flameData;
        //データ代入
        num_text.text   =   flame_num.ToString();   //フレーム番号
        word_text.text  =   wordData.word;          //単語名
        explain_text.text   =   wordData.explain;   //説明
        count_text.text =   wordData.count.ToString();  //コピー回数
        string update_date = wordData.update_date;      //時間
        string entry_date = wordData.entry_date;
        if (update_date == entry_date) {
            time_text.text = entry_date;
        } else {
            time_text.text = update_date + "(" + entry_date + ")";
        }
    }
}
