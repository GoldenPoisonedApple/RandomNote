using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameList
{
    //フレームデータ
    private List<I_FlameData> flame_data_list;
    //表示するデータ
    private List<I_FlameData> flame_view_list;
    //プレハブデータ
    private Transform flame_prehub;
    //親データ
    private Transform parent;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="flameDatas">リストにするデータ</param>
    /// <param name="flame_prehub">リストにするプレハブ</param>
    /// <param name="parent">プレハブの親要素</param>
    public FlameList (in List<I_FlameData> flameDatas, Transform flame_prehub, Transform parent)
    {
        //データ代入
        flame_data_list = flameDatas;
        this.flame_prehub = flame_prehub;
        this.parent = parent;
        //今の所データリスト順で
        flame_view_list = flame_data_list;

    }


    /// <summary>
    /// フレーム作成、表示
    /// </summary>
    private void create_flames()
    {
        // parentObject のすべての子オブジェクトを削除
        foreach (Transform child in parent) {   Object.Destroy(child.gameObject);    }
        // プレハブのI_Flameコンポーネント取得
        I_Flame flame = flame_prehub.GetComponent<I_Flame>();
        // データ代入
        foreach (I_FlameData flameData in flame_view_list)
        {
            //GameObject obj = Instantiate(flame_prehub.gameObject, flame_parent.position, Quaternion.identity);
        }

    }


}
