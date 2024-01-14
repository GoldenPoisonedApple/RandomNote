using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Test : MonoBehaviour {
    [SerializeField]
    private Button button;  //�e�X�g�����p�{�^��
    [SerializeField]
    private GameObject prehub;     //�v���n�u
    [SerializeField]
    private Transform parent;     //�v���n�u

    private void Start() {
        //���X�i�[�o�^
        //button.onClick.AddListener(OnClick);
        /*
        GameObject obj = Instantiate(prehub, parent.position, Quaternion.identity);
        obj.transform.SetParent(parent, false);
        obj.GetComponent<I_Flame>().ReflectData(new WordData(1, "�V�����P��", 2, "��������\n�V������\n����������", new List<int> { 1, 4, 5 }, "2023/5/6"), 6);
        GameObject obj_2 = Instantiate(prehub, parent.position, Quaternion.identity);
        obj_2.transform.SetParent(parent, false);
        obj_2.GetComponent<I_Flame>().ReflectData(new WordData(2, "��������", 5, "��������\n�V������\n����������\n�������", new List<int> { 1, 4, 5 }, "2023/5/3"), 12);
        */
        //�t�@�C���p�X
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        I_FileContent fileData = (new FileManager(file_path)).Load<FileData>();
        new FlameList(new FlameFactory(FlameFactory.FileType.WORD_FLAME, fileData));
    }

    
    /// <summary>
    /// ���o�^
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
