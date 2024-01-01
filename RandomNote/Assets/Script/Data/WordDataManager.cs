using System;
using System.IO;
using UnityEngine;

public class WordDataManager {

    /// <summary>
    /// パスを取得 & セーブファイル名記録
    /// </summary>
    private static string getFilePath() { return Application.persistentDataPath + "/WordData" + ".json"; }


    /// <summary>
    /// 書き込み機能
    /// </summary>
    /// <param name="paintDataWrapper">シリアライズするデータ</param>
    public static void Save(WordDataWrapper wordDataWarraper)
    {
        //シリアライズ実行
        string jsonSerializedData = JsonUtility.ToJson(wordDataWarraper);
        //Debug.Log(jsonSerializedData);

        //実際にファイル作って書き込む
        using (var sw = new StreamWriter(getFilePath(), false))
        {
            try
            {
                //ファイルに書き込む
                sw.Write(jsonSerializedData);
            }
            catch (Exception e) //失敗した時の処理
            {
                Debug.Log(e);
            }
        }
    }

    /// <summary>
    /// 読み込み機能
    /// </summary>
    /// <returns>デシリアライズした構造体</returns>
    public static WordDataWrapper Load()
    {
        WordDataWrapper jsonDeserializedData = new WordDataWrapper();

        try
        {
            //ファイルを読み込む
            using (FileStream fs = new FileStream(getFilePath(), FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string result = sr.ReadToEnd();
                //Debug.Log(result);

                //読み込んだJsonを構造体にぶちこむ
                jsonDeserializedData = JsonUtility.FromJson<WordDataWrapper>(result);
            }
        }
        catch (Exception e) //失敗した時の処理
        {
            Debug.Log(e);
        }

        //デシリアライズした構造体を返す
        return jsonDeserializedData;
    }
}