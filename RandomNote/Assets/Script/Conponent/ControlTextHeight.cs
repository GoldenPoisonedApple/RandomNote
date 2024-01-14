using System.Collections;
using UnityEngine;
using TMPro;

public class ControlTextHeight : MonoBehaviour
{
    /// <summary>
    /// �s���A�t�H���g�T�C�Y�ɍ��킹�č�����ύX
    /// �K���C���X�^���X��������Ɏ��s
    /// </summary>
    public void controlTextHeight()
    {
        //TMP_Text�R���|�[�l���g�����邩����
        if (this.GetComponent<TMP_Text>())
        {
            // ���̃X�N���v�g���A�^�b�`����Ă���Transform���擾
            GameObject obj = this.gameObject;
            TMP_Text text = obj.GetComponent<TMP_Text>();

            // 1�t���[���҂��Ă���T�C�Y�v�Z���s��
            StartCoroutine(DelayedSizeCalculation());

            IEnumerator DelayedSizeCalculation()
            {
                yield return null; // 1�t���[���҂�

                int lineCount = obj.GetComponent<TMP_Text>().textInfo.lineCount;
                //Debug.Log("�����ύX" + obj.GetComponent<TMP_Text>().textInfo.lineCount);

                //�T�C�Y�v�Z
                obj.GetComponent<RectTransform>().sizeDelta = new Vector2(obj.GetComponent<RectTransform>().sizeDelta.x, text.fontSize * lineCount);
            }

        }
    }
}
