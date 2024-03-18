using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameList
{
	// フレームデータ
	private I_FileContent fileContent;
	// 表示するデータ
	private List<I_FlameData> viewFlames;
	// タグコントローラ
	private I_TagControl tagControl;
	// プレハブデータ
	private GameObject flamePrehub;
	// フレームインスタンス
	private List<GameObject> flameInstances = new List<GameObject>();

	// フレームの親
	private GameObject flameParent;

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="flameFactory">フレームリストに必要な情報が格納されてる</param>
	public FlameList(FlameFactory flameFactory)
	{
		//情報取得
		flamePrehub = flameFactory.FlamePrehub;
		fileContent = flameFactory.FileContent;
		tagControl = fileContent.GetTagControl();
		//オブジェクト取得
		flameParent = GlobalObjData.Instance.getFlameParent();
		//表示
		viewFlames = fileContent.GetValidDatas();
		CreateFlames();
	}

	public void Test () {
		Debug.Log("テスト");
		tagControl.UpdateName(0, "タグ名変更テスト");
		ReflectTagUpdate();
	}

	/// <summary>
	/// フレーム作成、表示
	/// </summary>
	private void CreateFlames()
	{
		//子オブジェクト削除
		foreach (GameObject child in flameParent.transform) { Object.Destroy(child); }
		//インスタンス削除
		flameInstances.Clear();
		// データ代入
		int i = 0;
		foreach (I_FlameData flameData in viewFlames)
		{
			i++;

			//プレハブインスタンス作成
			GameObject instance = GlobalObjData.UseInstantiate(flamePrehub, flameParent.transform.position, Quaternion.identity);
			//データ反映
			I_Flame flame = instance.GetComponent<I_Flame>();
			flame.Reflect(i, flameData, tagControl);
			flame.AddListener();
			//親設定
			instance.transform.SetParent(flameParent.transform, false);
			//インスタンス保存
			flameInstances.Add(instance);
		}

		//vertical layout プレハブ実体化の1フレーム後にフレームの大きさが変わる事によるずれを修正するため、一度spacingを20fにしてから1フレーム後に30fに戻してる
		//変更が無いと更新がされなかった
		VerticalLayoutGroup layoutGroup = flameParent.GetComponent<VerticalLayoutGroup>();
		layoutGroup.spacing = 20f;
		GlobalObjData.Instance.Coroutine(() => layoutGroup.spacing = 30f);
	}

	private void ReflectTagUpdate() {
		for (int i=0; i<flameInstances.Count; i++) {
			flameInstances[i].GetComponent<I_Flame>().ReflectTagUpdate(tagControl);
		}
	}
}
