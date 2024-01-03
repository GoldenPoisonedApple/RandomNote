using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainScreen : MonoBehaviour
{
    [SerializeField]
    private Transform frameViewer;      //�t���[���r�����[
    [SerializeField]
    private Transform wordFrame;        //���[�h�t���[��


    //�萔
    const int FRAME_SPACE = 50;         //�t���[���Ԋu

    /*
    void Start() {
        //�f�[�^�ǂݍ���
        WordDataWrapper wordDataWrapper = WordDataManager.Load();
        //�t���[���쐬
        createFrame(wordDataWrapper);
    }

    /// <summary>
    /// �P��t���[���쐬�A�z�u
    /// </summary>
    private void createFrame (WordDataWrapper wordDataWrapper) {
        //�t���[���r�����[�ʒu�ݒ�
        frameViewer.position = new Vector2(0f, 0f);
        //�t���[���r�����[�����ݒ�
        float frame_viewer_height = 0;

        //�f�[�^�̐������J��Ԃ�
        for (int i = 0; i < wordDataWrapper.WordDataList.Count; i++)
        {

            //�t���[���C���X�^���X����
            GameObject frame_instance = Instantiate(wordFrame.gameObject, frameViewer.position, Quaternion.identity);
            //�t���[�������擾
            float frame_height = frame_instance.GetComponent<RectTransform>().sizeDelta.y;
            frame_viewer_height += frame_height + FRAME_SPACE;
            //�ʒu�ݒ�
            frame_instance.transform.position = new Vector2(frameViewer.position.x, -((frame_height + FRAME_SPACE) * i + FRAME_SPACE));
            //�e�q�֌W�\�z    ������:���ΓI�ȑ傫���ɃX�P�[����ύX���邩
            frame_instance.transform.SetParent(frameViewer, false);
        }

        //�t���[���r�����[�����ύX
        frameViewer.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, frame_viewer_height + FRAME_SPACE);
    }
    */

}
