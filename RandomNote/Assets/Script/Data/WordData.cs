using System;
using System.Collections.Generic;

/// <summary>
/// ���[�h�f�[�^������\����
/// </summary>
[Serializable]
public class WordData
{
    /// <summary>
    /// �o�^�ԍ�
    /// </summary>
    public int num;

    /// <summary>
    /// �P��
    /// </summary>
    public string word;

    /// <summary>
    /// ����
    /// </summary>
    public string explain;

    /// <summary>
    /// �]��
    /// </summary>
    public string star_num;

    /// <summary>
    /// �^�O�ԍ�
    /// </summary>
    public List<int> tag = new List<int>();
}