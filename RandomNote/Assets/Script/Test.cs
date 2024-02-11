using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Test : MonoBehaviour {
    [SerializeField]
    private Button button;  //テスト発動用ボタン
    [SerializeField]
    private GameObject prehub;     //プレハブ
    [SerializeField]
    private Transform parent;     //プレハブ

    private void Start() {
        //リスナー登録
        //button.onClick.AddListener(OnClick);
        /*
        GameObject obj = Instantiate(prehub, parent.position, Quaternion.identity);
        obj.transform.SetParent(parent, false);
        obj.GetComponent<I_Flame>().ReflectData(new WordData(1, "新しい単語", 2, "説明文も\n新しいよ\nもいっちょ", new List<int> { 1, 4, 5 }, "2023/5/6"), 6);
        GameObject obj_2 = Instantiate(prehub, parent.position, Quaternion.identity);
        obj_2.transform.SetParent(parent, false);
        obj_2.GetComponent<I_Flame>().ReflectData(new WordData(2, "もげもげ", 5, "説明文も\n新しいよ\nもいっちょ\n長いよね", new List<int> { 1, 4, 5 }, "2023/5/3"), 12);
        */
        //ファイルパス
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        I_FileContent fileData = (new FileManager(file_path)).Load<FileData>();
        new FlameList(new FlameFactory(FlameFactory.FileType.WORD_FLAME, fileData));
    }

    
    /// <summary>
    /// 情報登録
    /// </summary>
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
        tagDataWrapper.addTag("タグその5", 7);
        tagDataWrapper.addTag("タグその6", 7);
        tagDataWrapper.deleteTag(2);
        tagDataWrapper.deleteTag(5);
        tagDataWrapper.addTag("タグその7", 712);
        tagDataWrapper.addTag("タグその8", 21);
        tagDataWrapper.addTag("タグその9", 21);
        fileData.tagDatas = tagDataWrapper;

        //シリアライズ
        fileManager.Save(fileData);
    }
}
