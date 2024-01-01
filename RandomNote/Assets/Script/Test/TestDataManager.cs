using System;
using System.IO;
using UnityEngine;

public class TestDataManager {

    /// <summary>
    /// �p�X���擾 & �Z�[�u�t�@�C�����L�^
    /// </summary>
    private static string getFilePath() { return Application.persistentDataPath + "/PaintData" + ".json"; }


    /// <summary>
    /// �������݋@�\
    /// </summary>
    /// <param name="paintDataWrapper">�V���A���C�Y����f�[�^</param>
    public static void Save(TestDataWrapper testDataWarraper)
    {
        //�V���A���C�Y���s
        string jsonSerializedData = JsonUtility.ToJson(testDataWarraper);
        //Debug.Log(jsonSerializedData);

        //���ۂɃt�@�C������ď�������
        using (var sw = new StreamWriter(getFilePath(), false))
        {
            try {
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
    public static TestDataWrapper Load()
    {
        TestDataWrapper jsonDeserializedData = new TestDataWrapper();

        try
        {
            //�t�@�C����ǂݍ���
            using (FileStream fs = new FileStream(getFilePath(), FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string result = sr.ReadToEnd();
                Debug.Log(result);

                //�ǂݍ���Json���\���̂ɂԂ�����
                jsonDeserializedData = JsonUtility.FromJson<TestDataWrapper>(result);
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