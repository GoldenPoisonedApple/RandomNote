using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcess : MonoBehaviour {

    /// <summary>
    /// �ǂݍ��񂾃t�@�C�����
    /// </summary>
    private I_FileContent fileContent;

    // Start is called before the first frame update
    void Start() {
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        this.fileContent = new FileManager(file_path).Load();
        Debug.Log(fileContent);
    }

    /*
    private void Start () {
        //������TrailRenderer�̏����\���́A�y�у��X�g�Ɋi�[����
        TestDataWrapper testDataWrapper = new TestDataWrapper();
        TestData testData = new TestData();

        //�f�[�^�ǉ�
        testData.num = 0;
        testData.word = "�ق��ق�";

        //�\���̂����X�g�ɒǉ�
        testDataWrapper.DataList.Add(testData);
        //�V���A���C�Y
        //TestDataManager.Save(testDataWrapper);
    }

    public void OnClick () {
        Debug.Log("path : " + Application.persistentDataPath + "/PaintData" + ".json");
        Debug.Log(TestDataManager.Load());
    }
    */
}
