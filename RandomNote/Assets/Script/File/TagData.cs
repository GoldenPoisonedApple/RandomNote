using System;

/// <summary>
/// �^�O
/// </summary>
[Serializable]
public class TagData {

    /// <summary>
    /// �^�O�V�K�ꏊ�ɍ쐬���R���X�g���N�^
    /// end��first�ɂ����g��Ȃ�
    /// </summary>
    /// <param name="word">�^�O��</param>
    /// <param name="num">�^�O�ۑ��ԍ�</param>
    /// <param name="used_count">�g�p����Ă��鐔</param>
    /// <param name="pre">�O�̃^�O�ۑ��ԍ�</param>
    /// <param name="next">���̃^�O�ۑ��ԍ�</param>
    /// <param name="next">�^�O�̎��</param>
    public TagData (string word, int num, int used_count, int pre, int next, int state) {
        this.word = word;
        this.num = num;
        this.used_count = used_count;
        this.pre = pre;
        this.next = next;
        this.state = state;
    }
    /// <summary>
    /// �^�O�f�[�^�ǉ�
    /// </summary>
    /// <param name="word">�^�O��</param>
    /// <param name="num">�^�O�ۑ��ԍ�</param>
    /// <param name="used_count">�g�p����Ă��鐔</param>
    public void addData(string word, int num, int used_count) {
        this.word = word;
        this.num = num;
        this.used_count = used_count;
        this.state = DATA;
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

    /// <summary>
    /// �^�O�̎��, FIRST��END��DATA
    /// </summary>
    public int state;
    public const int FIRST = 0;
    public const int DATA = 1;
    public const int END = 2;
    public const int DELETE = 3;
}
