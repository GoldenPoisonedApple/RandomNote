using System;

/// <summary>
/// �P�ꃊ�X�g
/// </summary>
[Serializable]
public class FileListData : I_FlameData {
    /// <summary>
    /// �S���̓R���X�g���N�^
    /// </summary>
    public FileListData(string title, string path, bool is_locked, int word_num, string entry_date, string update_date) {
        this.title = title;
        this.path = path;
        this.is_locked = is_locked;
        this.word_num = word_num;
        this.entry_date = entry_date;
        this.update_date = update_date;
    }

    /// <summary>
    /// �^�C�g��
    /// </summary>
    public string title;

    /// <summary>
    /// �f�[�^�t�@�C���̃p�X
    /// </summary>
    public string path;

    /// <summary>
    /// �B���t�@�C�����ǂ���
    /// </summary>
    public bool is_locked;

    /// <summary>
    /// �P�ꐔ
    /// </summary>
    public int word_num;

    /// <summary>
    /// �쐬����
    /// </summary>
    public string entry_date;

    /// <summary>
    /// �X�V����
    /// </summary>
    public string update_date;
}
