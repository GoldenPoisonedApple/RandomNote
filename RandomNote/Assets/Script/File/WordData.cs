using System.Collections.Generic;

/// <summary>
/// �P��f�[�^
/// </summary>
public class WordData : I_FlameData {

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
