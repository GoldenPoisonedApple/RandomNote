using System;
using System.IO;
using UnityEngine;

public class FileManager {

    /// <summary>
    /// �f�[�^�ǂݍ��݁A�������݂���f�[�^�t�@�C���p�X
    /// </summary>
    private string file_path;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="file_path">�����œn�����t�@�C���ɑ΂��đ�����s��</param>
    public FileManager (string file_path) {
        this.file_path = file_path;
    }

    /// <summary>
    /// �������݋@�\
    /// </summary>
    /// <param name="paintDataWrapper">�V���A���C�Y����f�[�^</param>
    public void Save(I_FileContent fileContent) {
        
        string jsonSerializedData = JsonUtility.ToJson(fileContent);
        //���O�\��
        DebugControl.Log(jsonSerializedData);

        //���ۂɃt�@�C������ď�������
        using (var sw = new StreamWriter(file_path, false)) {
            try
            {
                //�t�@�C���ɏ�������(�㏑��)
                sw.Write(jsonSerializedData);
            }
            catch (Exception e) //���s�������̏���
            {
                DebugControl.Error(e);
            }
        }
    }

    /// <summary>
    /// �ǂݍ��݋@�\
    /// </summary>
    /// <returns>�f�V���A���C�Y�����\����</returns>
    public I_FileContent Load()
    {
        I_FileContent jsonDeserializedData = null;

        try
        {
            //�t�@�C����ǂݍ���
            using (FileStream fs = new FileStream(file_path, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string result = sr.ReadToEnd();
                DebugControl.Log(result);

                //�ǂݍ���Json���\���̂ɂԂ�����
                jsonDeserializedData = JsonUtility.FromJson<I_FileContent>(result);
            }
        }
        catch (Exception e) //���s�������̏���
        {
            DebugControl.Error(e);
        }

        //�f�V���A���C�Y�����\���̂�Ԃ�
        return jsonDeserializedData;
    }
}