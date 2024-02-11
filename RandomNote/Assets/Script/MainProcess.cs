using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcess : MonoBehaviour {

    /// <summary>
    /// 読み込んだファイル情報
    /// </summary>
    protected I_FileContent fileContent;

    // Start is called before the first frame update
    void Start() {
        string file_path = Application.persistentDataPath + "/WordsData" + ".json";
        this.fileContent = new FileManager(file_path).Load<FileData>();
        Debug.Log(fileContent);
    }
}
