using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Test : MonoBehaviour {
    [SerializeField]
    private Button button;  //�e�X�g�����p�{�^��

    private void Start() {
        //���X�i�[�o�^
        button.onClick.AddListener(OnClick);
    }

    /*
    public void OnClick () {
        Debug.Log("�{�^���������ꂽ");
        //�t�@�C���p�X
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        FileManager fileManager = new FileManager(file_path);

        //�f�[�^����
        FileListData file_list1 = new FileListData("�t�@�C��1", "aa/ff.c", false, 124, null, "2022/2/3");
        FileListData file_list2 = new FileListData("�t�@�C��2", "aa/fdesf.c", true, 11, "2022/2/2", "2022/6/3");

        FileListDataWrapper file_list_data = new FileListDataWrapper();
        file_list_data.pass_word = "hedowigu";
        file_list_data.listData.Add(file_list1);
        file_list_data.listData.Add(file_list2);

        //�V���A���C�Y
        fileManager.Save(file_list_data);
    }
    */

    
    /// <summary>
    /// �o�^
    /// </summary>
    public void OnClick()
    {
        Debug.Log("�{�^���������ꂽ");
        //�t�@�C���p�X
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        FileManager fileManager = new FileManager(file_path);

        //�f�[�^����
        FileData fileData = new FileData();
        fileData.title = "�e�X�g�P��W";
        fileData.is_locked = false;
        fileData.wordDatas.Add(new WordData(0, "�P�ꂻ��1", 3, "���������ē�����", new List<int>{1, 5, 7}, "2022/2/1"));
        fileData.wordDatas.Add(new WordData(1, "�P�ꂻ��2", 5, "���s\n�Ƃ��ǂ��Ȃ�񂾂낤", new List<int> { 7 }, "2022/2/3"));
        TagDataWrapper tagDataWrapper = new TagDataWrapper();
        tagDataWrapper.addTag("�^�O����1", 0);
        tagDataWrapper.addTag("�^�O����2", 9);
        tagDataWrapper.addTag("�^�O����3", 2);
        tagDataWrapper.addTag("�^�O����4", 1);
        tagDataWrapper.addTag("�^�O����5", 7);
        tagDataWrapper.addTag("�^�O����6", 7);
        tagDataWrapper.deleteTag(2);
        tagDataWrapper.deleteTag(5);
        tagDataWrapper.addTag("�^�O����7", 712);
        tagDataWrapper.addTag("�^�O����8", 21);
        tagDataWrapper.addTag("�^�O����9", 21);
        fileData.tagDatas = tagDataWrapper;

        //�V���A���C�Y
        fileManager.Save(fileData);
    }
}
