using System;
using System.Collections.Generic;

/// <summary>
/// �P��t�@�C���Q�̏��t�@�C��
/// </summary>
[Serializable]
public class FileListDataWrapper : I_FileContent {

    /// <summary>
    /// �B���t�@�C���p�X���[�h
    /// </summary>
    public string pass_word;

    /// <summary>
    /// �P�ꃊ�X�g�̃��X�g
    /// </summary>
    public List<FileListData> listData = new List<FileListData>();
}