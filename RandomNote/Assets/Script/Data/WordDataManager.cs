using System;
using System.IO;
using UnityEngine;

public class WordDataManager {

    /// <summary>
    /// �p�X���擾 & �Z�[�u�t�@�C�����L�^
    /// </summary>
    private static string getFilePath() { return Application.persistentDataPath + "/WordData" + ".json"; }


    /// <summary>
    /// �������݋@�\
    /// </summary>
    /// <param name="paintDataWrapper">�V���A���C�Y����f�[�^</param>
    public static void Save(WordDataWrapper wordDataWarraper)
    {
        //�V���A���C�Y���s
        string jsonSerializedData = JsonUtility.ToJson(wordDataWarraper);
        //Debug.Log(jsonSerializedData);

        //���ۂɃt�@�C������ď�������
        using (var sw = new StreamWriter(getFilePath(), false))
        {
            try
            {
                //�t�@�C���ɏ�������
                sw.Write(jsonSerializedData);
            }
            catch (Exception e) //���s�������̏���
            {
                Debug.Log(e);
            }
        }
    }

    /// <summary>
    /// �ǂݍ��݋@�\
    /// </summary>
    /// <returns>�f�V���A���C�Y�����\����</returns>
    public static WordDataWrapper Load()
    {
        WordDataWrapper jsonDeserializedData = new WordDataWrapper();

        try
        {
            //�t�@�C����ǂݍ���
            using (FileStream fs = new FileStream(getFilePath(), FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string result = sr.ReadToEnd();
                //Debug.Log(result);

                //�ǂݍ���Json���\���̂ɂԂ�����
                jsonDeserializedData = JsonUtility.FromJson<WordDataWrapper>(result);
            }
        }
        catch (Exception e) //���s�������̏���
        {
            Debug.Log(e);
        }

        //�f�V���A���C�Y�����\���̂�Ԃ�
        return jsonDeserializedData;
    }
}