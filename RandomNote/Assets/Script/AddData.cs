using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddData : MonoBehaviour {

    [SerializeField]
    private Transform addButton;      //追加ボタン
    [SerializeField]
    private GameObject inputPanel;      //表示切替パネル
    [SerializeField]
    private Transform returnPanel;      //戻る用パネル


    private void Start() {
        //リスナー登録
        addButton.GetComponent<Button>().onClick.AddListener(show_input_panel);
        returnPanel.GetComponent<Button>().onClick.AddListener(close_input_panel);
    }

    /// <summary>
    /// 入力パネル表示
    /// </summary>
    private void show_input_panel () {
        inputPanel.SetActive(true); // gameObjectをアクティブ化
    }

    /// <summary>
    /// 入力パネル非表示
    /// </summary>
    private void close_input_panel () {
       inputPanel.SetActive(false); // gameObjectを非アクティブ化
    }
}
