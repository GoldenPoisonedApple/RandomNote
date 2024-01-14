using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// オブジェクト情報
/// シングルトン
/// </summary>
public sealed class GlobalObjData : MonoBehaviour
{
    //インスタンス
    public static GlobalObjData Instance { get; private set; }
    //newすると怒られるため
    private void Awake() => Instance = this;
    //シングルトンコンストラクタ
    private GlobalObjData ()
    {
        //初期化処理はここに記述
    }

    /// <summary>
    /// MonoBehaviourないクラスでプレハブ実体化したいときに使うやつ
    /// </summary>
    /// <returns>インスタンス</returns>
    public static GameObject UseInstantiate (GameObject original, Vector3 position, Quaternion rotation)
    {
        return Instantiate(original, position, rotation);
    }

    /// <summary>
    /// MonoBehaviourないクラスでコルーチン使いたいときに使うやつ
    /// </summary>
    /// <param name="action">1フレーム後に実行される関数</param>
    public void Coroutine(Action action)
    {
        // 1フレーム待ってからサイズ計算を行う
        StartCoroutine(Delay());

        IEnumerator Delay()
        {
            yield return null; // 1フレーム待つ

            action();
        }
    }

    //FlameList
    [SerializeField]
    private GameObject flameParent;
    public GameObject getFlameParent () { return flameParent; }
    //FlameFactory
    [SerializeField]
    private GameObject fileFlamePrehub;   //ファイルのフレーム
    public GameObject getFileFlamePrehub() { return fileFlamePrehub; }
    [SerializeField]
    private GameObject wordFlamePrehub;  //単語のフレーム
    public GameObject getWordFlamePrehub() { return wordFlamePrehub; }
    //CopyToCripBoard
    [SerializeField]
    private GameObject popUp;  //ポップアップ
}
