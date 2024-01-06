using System;
using System.Collections.Generic;

/// <summary>
/// �t�@�C���f�[�^
/// </summary>
[Serializable]
public class FileData : I_FileContent {

    /// <summary>
    /// �P��Q�f�[�^�^�C�g��
    /// </summary>
    public string title;

    /// <summary>
    /// �B���t�@�C����
    /// </summary>
    public bool is_locked;

    /// <summary>
    /// �P��f�[�^���X�g
    /// </summary>
    public List<WordData> wordDatas = new List<WordData>();

    /// <summary>
    /// �^�O�f�[�^
    /// </summary>
    public TagDataWrapper tagDatas;
}