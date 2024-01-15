using UnityEngine;
using TMPro;

public class CopyToCripBoard : MonoBehaviour
{
    /// <summary>
    /// クリック時クリップボードにコピー
    /// </summary>
    /// <param name="text">コピー元</param>
    public void Onclick (TMP_Text text)
    {
        //クリップボードへ文字を設定(コピー)
        GUIUtility.systemCopyBuffer = text.text;
        DebugControl.Log("クリップボードにコピー : " + text.text);
        GlobalObjData.Instance.PopUp("クリップボードにコピーしました");
    }
}
