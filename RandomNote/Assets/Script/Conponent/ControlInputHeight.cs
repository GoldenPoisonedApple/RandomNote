using UnityEngine;
using TMPro;

public class ControlInputHeight : MonoBehaviour {

    [SerializeField]
    private Transform inputField;      //�����̒���������InputField
    [SerializeField]
    private Transform parent_control_pos_obj;      //���������̌�ʒu�𒲐�����I�u�W�F�N�g�̐e�v�f

    //�]��
    int SPACE = 15;


    public void control_inputfield_height () {
        //Debug.Log("�T�C�Y�ύX");
        int lineCount = inputField.GetComponent<TMP_InputField>().textComponent.textInfo.lineCount;
        //�T�C�Y�v�Z
        Vector2 after_size = new Vector2(inputField.GetComponent<RectTransform>().sizeDelta.x, inputField.GetComponent<TMP_InputField>().pointSize * lineCount + SPACE);
        //�ʒu����
        inputField.GetComponent<RectTransform>().sizeDelta = after_size;
        foreach (Transform item in parent_control_pos_obj) {
            RectTransform item_rect = item.GetComponent<RectTransform>();
            item_rect.offsetMax = new Vector2(0f, 0f);
            item_rect.offsetMin = new Vector2(0f, 0f);
        }
    }
}
