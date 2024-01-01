using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CopyButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text wordText;      //テキスト取得


    public void OnClickButton () {
        Debug.Log(wordText.text + "をコピーしました");
    }
}
