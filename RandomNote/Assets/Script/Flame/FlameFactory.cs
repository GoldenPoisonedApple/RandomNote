using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFactory {

    /// <summary>
    /// �t�@�C���̎��
    /// </summary>
    public enum FileType {
        FILE_FLAME,
        WORD_FLAME
    };

    //�t���[���f�[�^
    public List<I_FlameData> flameDatas { get; private set; }
    //�t���[���v���n�u
    public GameObject flamePrehub { get; private set; }
    //�\�[�g�n���v���n�u
    public GameObject sortPrehub { get; private set; }
    //�t�B���^�n���v���n�u
    public GameObject fillterPrehub { get; private set; }



    /// <summary>
    /// �t���[���ɕK�v�ȃf�[�^�쐬
    /// </summary>
    /// <param name="type">�t���[���̎��</param>
    /// <param name="fileContent">�t�@�C�����</param>
    public FlameFactory (FileType type, in I_FileContent fileContent)
    {
        GlobalObjData globalObjData = GlobalObjData.Instance;
        switch (type)
        {
            case FileType.FILE_FLAME :
                fileFlameFactory(in fileContent, globalObjData);
                break;
            case FileType.WORD_FLAME :
                wordFlameFactory(in fileContent, globalObjData);
                break;
        }
    }

    //�t�@�C���t���[��
    private void fileFlameFactory (in I_FileContent fileContent, GlobalObjData globalObjData)
    {
        flameDatas = ((FileListDataWrapper)fileContent).listData;   //�t���[���f�[�^���蓖��
        flamePrehub = globalObjData.getFileFlamePrehub();  //�t���[���v���n�u���蓖��
    }
    //���[�h�t���[��
    private void wordFlameFactory (in I_FileContent fileContent, GlobalObjData globalObjData)
    {
        flameDatas = ((FileData)fileContent).wordDatas.ConvertAll(x => (I_FlameData)x); ;   //�t���[���f�[�^���蓖��
        flamePrehub = globalObjData.getWordFlamePrehub();  //�t���[���v���n�u���蓖��
    }
}
