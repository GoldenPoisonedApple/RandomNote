using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

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
		GlobalObjData.Instance.createButtonText.text = "更新";	// ボタンテキストを"更新"に変更
		GlobalObjData.Instance.discardButtonText.text = "削除";	// ボタンテキストを"削除"に変更

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

	/// <summary>
	/// フレーム新規作成
	/// </summary>
	/// <param name="newFlameCount"></param>
	/// <param name="tagControl"></param>
	public void NewFlame (int newFlameCount, I_TagControl tagControl) {
		GlobalObjData.Instance.createButtonText.text = "作成";	// ボタンテキストを"作成"に変更
		GlobalObjData.Instance.discardButtonText.text = "破棄";	// ボタンテキストを"破棄"に変更

		// データ反映
		inputFlame.GetComponent<I_Flame>().NewInput(newFlameCount, tagControl);
	}

	/// <summary>
	/// 入力フレームデータ取得
	/// </summary>
	/// <returns>フレームデータ取得</returns>
	public I_FlameData GetFlameData () {
		return inputFlame.GetComponent<I_Flame>().GetFlameData();
	}
}