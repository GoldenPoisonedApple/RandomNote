using UnityEngine;

/// <summary>
/// �t���[���Ƃ��Ĉ����C���^�[�t�F�[�X
/// </summary>
public interface I_Flame {
    /// <summary>
    /// �t���[���쐬
    /// </summary>
    /// <param name="flameData">�t���[���ɕK�v�ȃf�[�^</param>
    /// <param name="flame_num">�t���[���ԍ�</param>
    void ReflectData(I_FlameData flameData, int flame_num);
}
