using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StarComponent : MonoBehaviour
{
	[SerializeField]
	private Sprite star_on;     //星アリ
	[SerializeField]
	private Sprite star_off;     //星ナシ

	/// <summary>
	/// 評価
	/// </summary>
	private int evaluation = 0;     //評価

	void Start ()
	{
		// リスナー登録
		int i = 0;
		foreach (Transform item in transform) {
			i++;
			if (item.GetComponent<Button>()) {
				int tmp = i;
				item.GetComponent<Button>().onClick.AddListener(() => {
					ReflectEvaluation(tmp);
				});
			}
		}
	}

	/// <summary>
	/// 評価設定
	/// </summary>
	/// <param name="evaluation">評価</param>
	public void ReflectEvaluation (int evaluation) {
		this.evaluation = evaluation;
		//星の表示
		for (int i = 0; i < transform.childCount; i++) {
			// 評価反映
			if (i < evaluation) {
				transform.GetChild(i).GetComponent<Image>().sprite = star_on;
			} else {
				transform.GetChild(i).GetComponent<Image>().sprite = star_off;
			}
		}
	}

	/// <summary>
	/// 評価取得
	/// </summary>
	/// <returns></returns>
	public int GetEvaluation () {
		return evaluation;
	}
}
