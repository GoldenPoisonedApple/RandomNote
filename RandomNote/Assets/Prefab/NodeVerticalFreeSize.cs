using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeVerticalFreeSize : TableNodeElement
{


    /// <summary>
    /// 初期化時コールされる
    /// </summary>
    public override void onInitialize()
    {

    }

    /// <summary>
    /// フォーカス ON/OFF の表示をここに記述する
    /// </summary>
    public override void onEffectFocus(bool focus, bool isAnimation)
    {

    }

    /// <summary>
    /// 行の表示更新通知があった場合、ここで表示を更新する
    /// </summary>
    public override void onEffectChange(int itemIndex)
    {

    }

    public override float GetCustomHeight(List<object> tbl, int itemIndex)
    {
        int no = (int)tbl[itemIndex];

        if ((no % 3) == 0)
        {
            return 200;
        }
        else
        if ((no % 3) == 1)
        {
            return 500;
        }
        else
        {
            return 300;
        }
    }

}
