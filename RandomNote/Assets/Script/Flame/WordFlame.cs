using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WordFlame : MonoBehaviour, I_Flame
{

    [SerializeField]
    private Transform flame_prehub;     //�t���[���v���n�u
    [SerializeField]
    private TMP_Text num_text;     //�t���[���ԍ�
    [SerializeField]
    private TMP_Text word_text;     //�P�ꖼ
    [SerializeField]
    private TMP_Text explain_text;     //����
    [SerializeField]
    private TMP_Text count_text;     //��
    [SerializeField]
    private TMP_Text time_text;     //����
    [SerializeField]
    private Transform[] stars;     //��
    [SerializeField]
    private Transform tag_prehub;     //�^�O

    /// <summary>
    /// ���[�h�t���[���Ƀf�[�^���f
    /// </summary>
    /// <param name="flameData">�t���[���ɔ��f������f�[�^</param>
    /// <param name="flame_num">�t���[���ԍ�</param>
    public void ReflectData(I_FlameData flameData, int flame_num)
    {
        WordData wordData = (WordData)flameData;
        //�f�[�^���
        num_text.text   =   flame_num.ToString();   //�t���[���ԍ�
        word_text.text  =   wordData.word;          //�P�ꖼ
        explain_text.text   =   wordData.explain;   //����
        count_text.text =   wordData.count.ToString();  //�R�s�[��
        string update_date = wordData.update_date;      //����
        string entry_date = wordData.entry_date;
        if (update_date == entry_date) {
            time_text.text = entry_date;
        } else {
            time_text.text = update_date + "(" + entry_date + ")";
        }
    }
}
