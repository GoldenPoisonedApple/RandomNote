using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flexibility : MonoBehaviour
{
	//Canvasの大きさ
	float screenHeight;

	private void Start()
	{
		//画面サイズ取得   scale with screen size のためScreen.heightだと上手くいかん
		//再帰的にCanvasを持つ親を探し、その大きさを取得
		screenHeight = this.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta.y;
		// 1フレーム待ってから処理を行う
		StartCoroutine(ForContentSizeFitter());
	}

	/// <summary>
	/// ContentSizeFitterが兄弟にある場合、そいつの大きさが0になってしまうのでコルーチンで次フレーム実行
	/// </summary>
	IEnumerator ForContentSizeFitter()
	{
		yield return null; // 1フレーム待つ
		yield return null; // もう1フレーム待つ 兄弟の子にContentSizeFitterがあった場合もう一回待たないといけない

		FlexSize();
	}

	public void FlexSize()
	{
		//兄弟オブジェクトの総高さ
		float otherHeight = 0;
		Transform parent = this.transform.parent;
		//親がちゃんといた場合
		if (parent != null)
		{
			// 子オブジェクトを全て取得する
			foreach (Transform child in parent)
			{
				//兄弟オブジェクトの総高計算
				if (child != this.transform)
				{
					//Debug.Log("broHeight : " + child.GetComponent<RectTransform>().sizeDelta.y);
					otherHeight += child.GetComponent<RectTransform>().sizeDelta.y;
					//Debug.Log("bro height" + child.GetComponent<RectTransform>().sizeDelta.y);
				}
			}
		}

		//Debug.Log("screen : " + screenHeight + ", other : " + otherHeight);
		//オブジェクトサイズ変更
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, (screenHeight - otherHeight));
	}
}
