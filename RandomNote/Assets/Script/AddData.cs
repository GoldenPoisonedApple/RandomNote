using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddData : MonoBehaviour {

    [SerializeField]
    private Transform addButton;      //�ǉ��{�^��
    [SerializeField]
    private GameObject inputPanel;      //�\���ؑփp�l��
    [SerializeField]
    private Transform returnPanel;      //�߂�p�p�l��


    private void Start() {
        //���X�i�[�o�^
        addButton.GetComponent<Button>().onClick.AddListener(show_input_panel);
        returnPanel.GetComponent<Button>().onClick.AddListener(close_input_panel);
    }

    /// <summary>
    /// ���̓p�l���\��
    /// </summary>
    private void show_input_panel () {
        inputPanel.SetActive(true); // gameObject���A�N�e�B�u��
    }

    /// <summary>
    /// ���̓p�l����\��
    /// </summary>
    private void close_input_panel () {
       inputPanel.SetActive(false); // gameObject���A�N�e�B�u��
    }
}
