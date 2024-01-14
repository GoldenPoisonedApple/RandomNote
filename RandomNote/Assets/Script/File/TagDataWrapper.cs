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
        pre_end = 0;
        end = pre_end + 1;
        //�ŏ��̃^�O�f�[�^�ۑ�
        tagData.Add(new TagData("first", pre_end, -1, -1, end, TagData.FIRST));
        //�Ō�̃^�O�f�[�^�ۑ�
        tagData.Add(new TagData("first", end, -1, pre_end, end+1, TagData.END));
    }

    /// <summary>
    /// �^�O�ǉ�
    /// </summary>
    /// <param name="tagName">�ǉ�����^�O�̖��O</param>
    /// <param name="used_count">�g�p����Ă��鐔</param>
    /// <returns>�ǉ������^�O�̕ۑ��ꏊ</returns>
    public int addTag(string tagName, int used_count)
    {
        //end�^�O�쐬
        if (tagData[end].state == TagData.END) {
            tagData.Add(new TagData("end", tagData[end].next, -1, end, end+2, TagData.END));
        }
        //�^�O�ǉ�
        tagData[end].addData(tagName, end, used_count);
        //end�ݒ�
        pre_end = end;
        end = tagData[end].next;

        //�ǉ������^�O�̕ۑ��ꏊ�Ԃ�
        return pre_end;
    }

    /// <summary>
    /// �^�O�폜
    /// </summary>
    /// <param name="tagNum">�^�O�̕ۑ��ꏊ</param>
    public void deleteTag(int tagNum)
    {
        try {
            if (tagNum == pre_end) {
                //end_pre�̃^�O�폜
                tagData[pre_end].state = TagData.DELETE;
                end = pre_end;
                pre_end = tagData[end].pre;

            } else {
                //���̑��̃^�O�폜
                tagData[tagNum].state = TagData.DELETE;
                tagData[tagData[tagNum].pre].next = tagData[tagNum].next;
                tagData[tagData[tagNum].next].pre = tagData[tagNum].pre;
                //�^�O��u
                tagData[tagNum].pre = pre_end;
                tagData[tagNum].next = end;
                tagData[pre_end].next = tagNum;
                tagData[end].pre = tagNum;
                //end�ݒ�
                end = tagNum;

            }
        } catch (Exception e) {
            DebugControl.Error(e);
        }
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
}