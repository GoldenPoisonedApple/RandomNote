using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Shapes2D;

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
        // 1フレーム待ってから処理を行う
        StartCoroutine(Delay());

        IEnumerator Delay()
        {
            yield return null; // 1フレーム待つ
            action();
        }
    }

    /// <summary>
    /// ポップアップメッセージ表示
    /// </summary>
    /// <param name="message">表示内容</param>
    public void PopUp (string message)
    {
        popUpMessage.text = message;
        popUp.GetComponent<Animator>().Play("PopUp", 0, 0.0f);
    }

    //FlameList
    [SerializeField]
    private GameObject flameParent;
    public GameObject getFlameParent () { return flameParent; }
    //FlameFactory
    [SerializeField]
    private GameObject fileFlamePrehub;   //ファイルのフレーム
    [SerializeField]
    private GameObject wordFlamePrehub;  //単語のフレーム
		/// <summary>
		/// フレームプレハブ取得
		/// </summary>
		/// <param name="type">タイプ</param>
		/// <returns></returns>
    public GameObject GetFlamePrehub(I_FileContent.FileType type)
		{
				if (type == I_FileContent.FileType.FILE_LIST) { return fileFlamePrehub; }
				else if (type == I_FileContent.FileType.WORD) { return wordFlamePrehub; }
				else { return null; }
		}
		[SerializeField]
    private GameObject wordInputFlamePrehub;  //単語のフレーム
		/// <summary>
		/// 入力フレームプレハブ取得
		/// </summary>
		/// <param name="type">タイプ</param>
		/// <returns></returns>
    public GameObject GetInputFlamePrehub(I_FileContent.FileType type)
		{
				if (type == I_FileContent.FileType.FILE_LIST) { return null; }
				else if (type == I_FileContent.FileType.WORD) { return wordInputFlamePrehub; }
				else { return null; }
		}
    //CopyToCripBoard
    [SerializeField]
    private GameObject popUp;  //ポップアップ
    [SerializeField]
    private TMP_Text popUpMessage;  //ポップアップ
		// フレーム入力パネル関係
		[SerializeField]
		public GameObject inputPanel;  //入力パネル
		[SerializeField]
		public TMP_Text createButtonText;	//作成ボタンテキスト
		[SerializeField]
		public TMP_Text discardButtonText;	//破棄・削除ボタンテキスト
}
