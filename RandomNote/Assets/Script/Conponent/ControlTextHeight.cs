using System.Collections;
using UnityEngine;
using TMPro;

public class ControlTextHeight : MonoBehaviour
{
	/// <summary>
	/// 行数、フォントサイズに合わせて高さを変更
	/// 必ずインスタンス化した後に実行
	/// </summary>
	public void controlTextHeight()
	{
		//TMP_Textコンポーネントがあるか判定
		if (this.GetComponent<TMP_Text>())
		{
			// このスクリプトがアタッチされているTransformを取得
			GameObject obj = this.gameObject;
			TMP_Text text = obj.GetComponent<TMP_Text>();

			// 1フレーム待ってからサイズ計算を行う
			StartCoroutine(DelayedSizeCalculation());

			IEnumerator DelayedSizeCalculation()
			{
				yield return null; // 1フレーム待つ

				int lineCount = obj.GetComponent<TMP_Text>().textInfo.lineCount;
				//Debug.Log("高さ変更" + obj.GetComponent<TMP_Text>().textInfo.lineCount);

				//サイズ計算
				obj.GetComponent<RectTransform>().sizeDelta = new Vector2(obj.GetComponent<RectTransform>().sizeDelta.x, text.fontSize * lineCount);
			}

		}
	}
}
