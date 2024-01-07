using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Test : MonoBehaviour {
    [SerializeField]
    private Button button;  //テスト発動用ボタン

    private void Start() {
        //リスナー登録
        button.onClick.AddListener(OnClick);
    }

    /*
    public void OnClick () {
        Debug.Log("ボタンが押された");
        //ファイルパス
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        FileManager fileManager = new FileManager(file_path);

        //データ入力
        FileListData file_list1 = new FileListData("ファイル1", "aa/ff.c", false, 124, null, "2022/2/3");
        FileListData file_list2 = new FileListData("ファイル2", "aa/fdesf.c", true, 11, "2022/2/2", "2022/6/3");

        FileListDataWrapper file_list_data = new FileListDataWrapper();
        file_list_data.pass_word = "hedowigu";
        file_list_data.listData.Add(file_list1);
        file_list_data.listData.Add(file_list2);

        //シリアライズ
        fileManager.Save(file_list_data);
    }
    */

    public void OnClick()
    {
        Debug.Log("ボタンが押された");
        //ファイルパス
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        FileManager fileManager = new FileManager(file_path);

        //データ入力
        FileData fileData = new FileData();
        fileData.title = "テスト単語集";
        fileData.is_locked = false;
        fileData.wordDatas.Add(new WordData(0, "単語その1", 3, "説明文って難しいよね", new List<int>{1, 5, 7}, "2022/2/1"));
        fileData.wordDatas.Add(new WordData(1, "単語その2", 5, "改行\nとかどうなるんだろう", new List<int> { 7 }, "2022/2/3"));
        TagDataWrapper tagDataWrapper = new TagDataWrapper();
        tagDataWrapper.addTag("タグその1", 0);
        tagDataWrapper.addTag("タグその2", 9);
        tagDataWrapper.addTag("タグその3", 2);
        tagDataWrapper.addTag("タグその4", 1);
        fileData.tagDatas = tagDataWrapper;

        //シリアライズ
        fileManager.Save(fileData);
    }
}
