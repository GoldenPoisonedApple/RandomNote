using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameList
{
    //�t���[���f�[�^
    private List<I_FlameData> flameDatas;
    //�\������f�[�^
    private List<I_FlameData> flameViewDatas;
    //�v���n�u�f�[�^
    private GameObject flamePrehub;

    //�t���[���̐e
    private GameObject flameParent;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="flameFactory">�t���[�����X�g�ɕK�v�ȏ�񂪊i�[����Ă�</param>
    public FlameList (FlameFactory flameFactory)
    {
        //���擾
        flamePrehub = flameFactory.flamePrehub;
        flameDatas = flameFactory.flameDatas;
        //�I�u�W�F�N�g�擾
        flameParent = GlobalObjData.Instance.getFlameParent();
        //�\��
        flameViewDatas = flameDatas;
        create_flames();
    }


    /// <summary>
    /// �t���[���쐬�A�\��
    /// </summary>
    private void create_flames()
    {
        //�q�I�u�W�F�N�g�폜
        foreach (GameObject child in flameParent.transform) { Object.Destroy(child); }
        // �f�[�^���
        int i = 0;
        foreach (I_FlameData flameData in flameViewDatas)
        {
            i++;

            //�v���n�u�C���X�^���X�쐬
            GameObject obj = GlobalObjData.UseInstantiate(flamePrehub, flameParent.transform.position, Quaternion.identity);
            //�f�[�^���f
            obj.GetComponent<I_Flame>().ReflectData(flameData, i);
            //�e�ݒ�
            obj.transform.SetParent(flameParent.transform, false);
        }

        //vertical layout �v���n�u���̉���1�t���[����Ƀt���[���̑傫�����ς�鎖�ɂ�邸����C�����邽�߁A��xspacing��20f�ɂ��Ă���1�t���[�����30f�ɖ߂��Ă�
        //�ύX�������ƍX�V������Ȃ�����
        VerticalLayoutGroup layoutGroup = flameParent.GetComponent<VerticalLayoutGroup>();
        layoutGroup.spacing = 20f;
        GlobalObjData.Instance.Coroutine(() => layoutGroup.spacing = 30f);
    }


}
