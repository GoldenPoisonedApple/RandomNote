using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CopyButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text wordText;      //�e�L�X�g�擾


    public void OnClickButton () {
        Debug.Log(wordText.text + "���R�s�[���܂���");
    }
}
