using System;
using System.Collections.Generic;

/// <summary>
/// �P�ꃊ�X�g
/// </summary>
[Serializable]
public class TagDataWrapper {
    /// <summary>
    /// �쐬���R���X�g���N�^
    /// </summary>
    public TagDataWrapper () {
        end = 1;
        pre_end = 0;
        //�ŏ��̃^�O�f�[�^�ۑ�
        tagData.Add(new TagData("first", 0, -1, -1, 1));
    }

    /// <summary>
    /// ���f�[�^���̓^�O�ۑ��ԍ�
    /// </summary>
    public int end;

    /// <summary>
    /// ���X�g�f�[�^���̓^�O�ۑ��ԍ�
    /// </summary>
    public int pre_end;

    /// <summary>
    /// �P�ꃊ�X�g�̃��X�g
    /// </summary>
    public List<TagData> tagData = new List<TagData>();

    /// <summary>
    /// �^�O�ǉ�
    /// </summary>
    /// <param name="tagName">�ǉ�����^�O�̖��O</param>
    /// <param name="used_count">�g�p����Ă��鐔</param>
    /// <returns>�ǉ������^�O�̕ۑ��ꏊ</returns>
    public int addTag(string tagName, int used_count) {
        if (tagData.Count <= end)
        {
            //�V�����ꏊ�ɍ��ꍇ
            tagData.Add(new TagData(tagName, end, used_count, pre_end, end + 1));
        }
        else
        {
            //�^�O���������ꏊ�ɍ��ꍇ
            tagData[end].addData(tagName, end, used_count, pre_end);
        }

        //���f�[�^�̂��߂�
        pre_end = end;
        end = tagData[end].next;

        //�ǉ������^�O�̕ۑ��ꏊ�Ԃ�
        return pre_end;
    }

    /// <summary>
    /// �^�O�폜
    /// </summary>
    /// <param name="TagNum">�^�O�̕ۑ��ꏊ</param>
    public void deleteTag (int TagNum) {
        try
        {
            //�^�O�폜
            tagData.RemoveAt(TagNum);

        } catch (Exception e)
        {
            DebugControl.Error(e);
        }
    }
}