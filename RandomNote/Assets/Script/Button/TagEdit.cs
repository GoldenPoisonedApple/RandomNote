using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagEdit : MonoBehaviour
{
    [SerializeField]
    private GameObject flex;


    public void OnButton()
    {
        Debug.Log("ボタン押された");
        flex.GetComponent<Flexibility>().FlexSize();
    }
}
