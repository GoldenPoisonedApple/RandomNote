using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {

    [SerializeField]
    private Transform[] stars;      //��


    public int value = 0;               //�]��


    //���̐F
    private Color star_color = new Color(0xff, 0xd0, 0x00);
    //���̐F
    private Color star_color_default = new Color(0xff, 0xff, 0xff);

    void Start()
    {
        //���X�i�[�ݒ�
        for (int i=0; i<stars.Length; i++) {
            int tmp = i;
            stars[i].GetComponent<Button>().onClick.AddListener(() => { set_value(tmp); });
        }
    }

    /// <summary>
    /// �]���ύX
    /// </summary>
    /// <param name="star_num">�]���̐�</param>
    private void set_value (int star_num) {
        int i = 0;
        //�]���̐��������
        for ( ; i<star_num+1; i++) {
            stars[i].GetComponent<Image>().color = star_color;
        }
        //�]���ݒ�
        value = i;
        //�c��𔒂ɂ���
        for ( ; i < stars.Length; i++) {
            stars[i].GetComponent<Image>().color = star_color_default;
        }
    }
    
}
