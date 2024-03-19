using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InputFlame : MonoBehaviour
{
	[SerializeField]
	private GameObject flameParent;     //プレハブ配置場所

	private GameObject inputFlame;     // 入力フレーム

	/// <summary>
	/// フレーム作成
	/// </summary>
	/// <param name="inputFlamePrehub">入力フレームプレハブ</param>
	public void SetFlamePrehub(GameObject inputFlamePrehub)
	{
		// プレハブ配置場所の子オブジェクトを全て削除
		foreach (Transform child in flameParent.transform) { Destroy(child.gameObject); }
		// flamePrehubをインスタンスして配置
		inputFlame = Instantiate(inputFlamePrehub);
		//親設定
		inputFlame.transform.SetParent(flameParent.transform, false);
	}

	/// <summary>
	/// フレームデータ反映
	/// </summary>
	/// <param name="flame_num"></param>
	/// <param name="flameData"></param>
	/// <param name="tagControl"></param>
	/// <param name="flamePrehub"></param>
	public void SetFlame(int flame_num, I_FlameData flameData, I_TagControl tagControl)
	{
		// データ反映
		inputFlame.GetComponent<I_Flame>().ReflectInput(flame_num, flameData, tagControl);

		// サイズ更新
		StartCoroutine(Delay());
		IEnumerator Delay()
		{
			yield return null; // 1フレーム待つ
			inputFlame.GetComponent<VerticalLayoutGroup>().enabled = false;
			inputFlame.GetComponent<VerticalLayoutGroup>().enabled = true;
		}
	}

	public void newFlame (int newFlameCount, I_TagControl tagControl) {
		// データ反映
		inputFlame.GetComponent<I_Flame>().NewInput(newFlameCount, tagControl);
	}
}