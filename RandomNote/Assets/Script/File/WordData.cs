using System;
using System.Collections.Generic;

/// <summary>
/// �P��f�[�^
/// </summary>
[Serializable]
public class WordData : I_FlameData {
    /// <summary>
    /// �V�K�쐬���R���X�g���N�^
    /// �X�V�����͐V�K�쐬�����Ɠ����ɂȂ�
    /// �R�s�[�񐔂�0�������l�Ƃ��ē������
    /// </summary>
    /// <param name="num">�o�^�ԍ�</param>
    /// <param name="word">�P�ꖼ</param>
    /// <param name="star_num">�]��</param>
    /// <param name="explain">����</param>
    /// <param name="tags">�^�O</param>
    /// <param name="entry_date">�쐬����</param>
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
    /// �o�^�ԍ�
    /// </summary>
    public int num;

    /// <summary>
    /// �P�ꖼ
    /// </summary>
    public string word;

    /// <summary>
    /// �R�s�[��
    /// </summary>
    public int count;

    /// <summary>
    /// �]��  0�̓G���[ 1�`5
    /// </summary>
    public short star_num;

    /// <summary>
    /// ������
    /// </summary>
    public string explain;

    /// <summary>
    /// �^�O���
    /// </summary>
    public List<int> tags = new List<int>();

    /// <summary>
    /// �쐬����
    /// </summary>
    public string entry_date;

    /// <summary>
    /// �X�V����
    /// </summary>
    public string update_date;
}
