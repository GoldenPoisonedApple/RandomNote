using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �I�u�W�F�N�g���
/// �V���O���g��
/// </summary>
public sealed class GlobalObjData : MonoBehaviour
{
    //�C���X�^���X
    public static GlobalObjData Instance { get; private set; }
    //new����Ɠ{���邽��
    private void Awake() => Instance = this;
    //�V���O���g���R���X�g���N�^
    private GlobalObjData ()
    {
        //�����������͂����ɋL�q
    }

    /// <summary>
    /// MonoBehaviour�Ȃ��N���X�Ńv���n�u���̉��������Ƃ��Ɏg�����
    /// </summary>
    /// <returns>�C���X�^���X</returns>
    public static GameObject UseInstantiate (GameObject original, Vector3 position, Quaternion rotation)
    {
        return Instantiate(original, position, rotation);
    }

    /// <summary>
    /// MonoBehaviour�Ȃ��N���X�ŃR���[�`���g�������Ƃ��Ɏg�����
    /// </summary>
    /// <param name="action">1�t���[����Ɏ��s�����֐�</param>
    public void Coroutine(Action action)
    {
        // 1�t���[���҂��Ă���T�C�Y�v�Z���s��
        StartCoroutine(Delay());

        IEnumerator Delay()
        {
            yield return null; // 1�t���[���҂�

            action();
        }
    }

    //FlameList
    [SerializeField]
    private GameObject flameParent;
    public GameObject getFlameParent () { return flameParent; }
    //FlameFactory
    [SerializeField]
    private GameObject fileFlamePrehub;   //�t�@�C���̃t���[��
    public GameObject getFileFlamePrehub() { return fileFlamePrehub; }
    [SerializeField]
    private GameObject wordFlamePrehub;  //�P��̃t���[��
    public GameObject getWordFlamePrehub() { return wordFlamePrehub; }
    //CopyToCripBoard
    [SerializeField]
    private GameObject popUp;  //�|�b�v�A�b�v
}
