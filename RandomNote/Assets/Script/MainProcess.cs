using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcess : MonoBehaviour {

    /// <summary>
    /// 読み込んだファイル情報
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
        //ここでTrailRendererの情報を構造体、及びリストに格納する
        TestDataWrapper testDataWrapper = new TestDataWrapper();
        TestData testData = new TestData();

        //データ追加
        testData.num = 0;
        testData.word = "ほげほげ";

        //構造体をリストに追加
        testDataWrapper.DataList.Add(testData);
        //シリアライズ
        //TestDataManager.Save(testDataWrapper);
    }

    public void OnClick () {
        Debug.Log("path : " + Application.persistentDataPath + "/PaintData" + ".json");
        Debug.Log(TestDataManager.Load());
    }
    */
}
