using UnityEngine;
using TMPro;

public class ControlInputHeight : MonoBehaviour {

    [SerializeField]
    private Transform inputField;      //高さの調整をするInputField
    [SerializeField]
    private Transform parent_control_pos_obj;      //高さ調整の後位置を調整するオブジェクトの親要素

    //余白
    int SPACE = 15;


    public void control_inputfield_height () {
        //Debug.Log("サイズ変更");
        int lineCount = inputField.GetComponent<TMP_InputField>().textComponent.textInfo.lineCount;
        //サイズ計算
        Vector2 after_size = new Vector2(inputField.GetComponent<RectTransform>().sizeDelta.x, inputField.GetComponent<TMP_InputField>().pointSize * lineCount + SPACE);
        //位置調整
        inputField.GetComponent<RectTransform>().sizeDelta = after_size;
        foreach (Transform item in parent_control_pos_obj) {
            RectTransform item_rect = item.GetComponent<RectTransform>();
            item_rect.offsetMax = new Vector2(0f, 0f);
            item_rect.offsetMin = new Vector2(0f, 0f);
        }
    }
}
