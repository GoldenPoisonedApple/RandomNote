using UnityEngine;
using TMPro;

public class CopyToCripBoard : MonoBehaviour
{
    /// <summary>
    /// �N���b�N���N���b�v�{�[�h�ɃR�s�[
    /// </summary>
    /// <param name="text">�R�s�[��</param>
    public void Onclick (TMP_Text text)
    {
        //�N���b�v�{�[�h�֕�����ݒ�(�R�s�[)
        GUIUtility.systemCopyBuffer = text.text;
        DebugControl.Log("�N���b�v�{�[�h�ɃR�s�[ : " + text.text);
        GlobalObjData.Instance.PopUp("�N���b�v�{�[�h�ɃR�s�[���܂���");
    }
}
