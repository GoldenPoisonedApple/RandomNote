using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameList
{
    //フレームデータ
    private List<I_FlameData> flameDatas;
    //表示するデータ
    private List<I_FlameData> flameViewDatas;
    //プレハブデータ
    private GameObject flamePrehub;

    //フレームの親
    private GameObject flameParent;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="flameFactory">フレームリストに必要な情報が格納されてる</param>
    public FlameList (FlameFactory flameFactory)
    {
        //情報取得
        flamePrehub = flameFactory.flamePrehub;
        flameDatas = flameFactory.flameDatas;
        //オブジェクト取得
        flameParent = GlobalObjData.Instance.getFlameParent();
        //表示
        flameViewDatas = flameDatas;
        create_flames();
    }


    /// <summary>
    /// フレーム作成、表示
    /// </summary>
    private void create_flames()
    {
        //子オブジェクト削除
        foreach (GameObject child in flameParent.transform) { Object.Destroy(child); }
        // データ代入
        int i = 0;
        foreach (I_FlameData flameData in flameViewDatas)
        {
            i++;

            //プレハブインスタンス作成
            GameObject obj = GlobalObjData.UseInstantiate(flamePrehub, flameParent.transform.position, Quaternion.identity);
            //データ反映
            obj.GetComponent<I_Flame>().ReflectData(flameData, i);
            //親設定
            obj.transform.SetParent(flameParent.transform, false);
        }

        //vertical layout プレハブ実体化の1フレーム後にフレームの大きさが変わる事によるずれを修正するため、一度spacingを20fにしてから1フレーム後に30fに戻してる
        //変更が無いと更新がされなかった
        VerticalLayoutGroup layoutGroup = flameParent.GetComponent<VerticalLayoutGroup>();
        layoutGroup.spacing = 20f;
        GlobalObjData.Instance.Coroutine(() => layoutGroup.spacing = 30f);
    }


}
