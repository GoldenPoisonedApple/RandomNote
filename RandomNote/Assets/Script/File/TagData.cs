using System;

/// <summary>
/// �^�O
/// </summary>
[Serializable]
public class TagData {
    
    /// <summary>
    /// �^�O�V�K�ꏊ�ɍ쐬���R���X�g���N�^
    /// </summary>
    /// <param name="word">�^�O��</param>
    /// <param name="num">�^�O�ۑ��ԍ�</param>
    /// <param name="used_count">�g�p����Ă��鐔</param>
    /// <param name="pre">�O�̃^�O�ۑ��ԍ�</param>
    /// <param name="next">���̃^�O�ۑ��ԍ�</param>
    public TagData (string word, int num, int used_count, int pre, int next) {
        this.word = word;
        this.num = num;
        this.used_count = used_count;
        this.pre = pre;
        this.next = next;
    }
    /// <summary>
    /// �^�O�����ꏊ�ɒǉ�
    /// pre�͂��Ȃ��Ă��ǂ����ی�
    /// </summary>
    /// <param name="word">�^�O��</param>
    /// <param name="num">�^�O�ۑ��ԍ�</param>
    /// <param name="used_count">�g�p����Ă��鐔</param>
    /// <param name="pre">�O�̃^�O�ۑ��ԍ�</param>
    public void addData(string word, int num, int used_count, int pre) {
        this.word = word;
        this.num = num;
        this.used_count = used_count;
        this.pre = pre;
    }

    /// <summary>
    /// �^�O��
    /// </summary>
    public string word;

    /// <summary>
    /// �^�O�ۑ��ԍ�
    /// </summary>
    public int num;

    /// <summary>
    /// �g�p����Ă��鐔
    /// </summary>
    public int used_count;

    /// <summary>
    /// �O�̃^�O�ۑ��ԍ�
    /// </summary>
    public int pre;

    /// <summary>
    /// ���̃^�O�ۑ��ԍ�
    /// </summary>
    public int next;
}
