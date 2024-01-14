using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WordFlame : MonoBehaviour, I_Flame
{
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
    private Image[] stars;     //��
    [SerializeField]
    private Sprite star_on;     //���A��
    [SerializeField]
    private Sprite star_off;     //���i�V
    [SerializeField]
    private Transform tag_prehub;     //�^�O

    /// <summary>
    /// ���[�h�t���[���Ƀf�[�^���f
    /// �K���C���X�^���X��������Ɏ��s
    /// </summary>
    /// <param name="flameData">�t���[���ɔ��f������f�[�^</param>
    /// <param name="flame_num">�t���[���ԍ�</param>
    public void ReflectData(I_FlameData flameData, int flame_num)
    {
        WordData wordData = (WordData)flameData;
        //�f�[�^���
        num_text.text   =   flame_num.ToString();   //�t���[���ԍ�
        word_text.text  =   wordData.word;          //�P�ꖼ
        set_explain(wordData.explain);   //����
        count_text.text =   wordData.count.ToString();  //�R�s�[��
        set_date(wordData.update_date, wordData.entry_date);  //����
        set_star(wordData.star_num);    //��
    }

    //�������ݒ�
    private void set_explain (string explain)
    {
        explain_text.text = explain;
        explain_text.GetComponent<ControlTextHeight>().controlTextHeight(); //��������
    }

    //���Ԑݒ�
    private void set_date (string update_date, string entry_date)
    {
        if (update_date == entry_date)
        {
            time_text.text = entry_date;
        }
        else
        {
            time_text.text = update_date + "(" + entry_date + ")";
        }
    }

    //�]���ݒ�
    private void set_star(int star_num)
    {
        int i = 0;
        //�]���̐��������
        for (; i < star_num; i++)
        {
            stars[i].sprite = star_on;
        }
        //�c��𔒂ɂ���
        for (; i < stars.Length; i++)
        {
            stars[i].sprite = star_off;
        }
    }
}
