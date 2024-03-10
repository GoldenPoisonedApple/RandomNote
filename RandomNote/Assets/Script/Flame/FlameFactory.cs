using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFactory {

    /// <summary>
    /// ファイルの種類
    /// </summary>
    public enum FileType {
        FILE_FLAME,
        WORD_FLAME
    };

    //フレームデータ
    public List<I_FlameData> flameDatas { get; private set; }
    //フレームプレハブ
    public GameObject flamePrehub { get; private set; }
    //ソート系統プレハブ
    public GameObject sortPrehub { get; private set; }
    //フィルタ系統プレハブ
    public GameObject fillterPrehub { get; private set; }



    /// <summary>
    /// フレームに必要なデータ作成
    /// </summary>
    /// <param name="type">フレームの種類</param>
    /// <param name="fileContent">ファイル情報</param>
    public FlameFactory (FileType type, in I_FileContent fileContent)
    {
        GlobalObjData globalObjData = GlobalObjData.Instance;
        switch (type)
        {
            case FileType.FILE_FLAME :
                fileFlameFactory(in fileContent, globalObjData);
                break;
            case FileType.WORD_FLAME :
                wordFlameFactory(in fileContent, globalObjData);
                break;
        }
    }

    //ファイルフレーム
    private void fileFlameFactory (in I_FileContent fileContent, GlobalObjData globalObjData)
    {
        flameDatas = ((FileListDataWrapper)fileContent).listDatas.ConvertAll(item => (I_FlameData)item);   //フレームデータ割り当て
        flamePrehub = globalObjData.getFileFlamePrehub();  //フレームプレハブ割り当て
    }
    //ワードフレーム
    private void wordFlameFactory (in I_FileContent fileContent, GlobalObjData globalObjData)
    {
        flameDatas = ((FileData)fileContent).wordDatas.GetFlameDatas();   //フレームデータ割り当て
        flamePrehub = globalObjData.getWordFlamePrehub();  //フレームプレハブ割り当て
    }
}
