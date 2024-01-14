using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameList
{
    //�t���[���f�[�^
    private List<I_FlameData> flame_data_list;
    //�\������f�[�^
    private List<I_FlameData> flame_view_list;
    //�v���n�u�f�[�^
    private Transform flame_prehub;
    //�e�f�[�^
    private Transform parent;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="flameDatas">���X�g�ɂ���f�[�^</param>
    /// <param name="flame_prehub">���X�g�ɂ���v���n�u</param>
    /// <param name="parent">�v���n�u�̐e�v�f</param>
    public FlameList (in List<I_FlameData> flameDatas, Transform flame_prehub, Transform parent)
    {
        //�f�[�^���
        flame_data_list = flameDatas;
        this.flame_prehub = flame_prehub;
        this.parent = parent;
        //���̏��f�[�^���X�g����
        flame_view_list = flame_data_list;

    }


    /// <summary>
    /// �t���[���쐬�A�\��
    /// </summary>
    private void create_flames()
    {
        // parentObject �̂��ׂĂ̎q�I�u�W�F�N�g���폜
        foreach (Transform child in parent) {   Object.Destroy(child.gameObject);    }
        // �v���n�u��I_Flame�R���|�[�l���g�擾
        I_Flame flame = flame_prehub.GetComponent<I_Flame>();
        // �f�[�^���
        foreach (I_FlameData flameData in flame_view_list)
        {
            //GameObject obj = Instantiate(flame_prehub.gameObject, flame_parent.position, Quaternion.identity);
        }

    }


}
