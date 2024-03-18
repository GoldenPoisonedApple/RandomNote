using UnityEngine;
using TMPro;
using System.Collections;


/// <summary>
/// InputFieldの高さを変更する
/// </summary>
public class ControlInputHeight : MonoBehaviour
{
	[SerializeField]
	private Transform parent_control_pos_obj;      //InputFeildに伴ったサイズ変更をする必要のobjの親

	//ちょっとスペースあける
	readonly int SPACE = 15;


	public void control_inputfield_height()
	{
		// インスタンスしてから1フレーム後に実行
		StartCoroutine(Delay());

		IEnumerator Delay () {
			yield return null; // 1フレーム待つ
			//行数取得
			int lineCount = transform.GetComponent<TMP_InputField>().textComponent.textInfo.lineCount;
			//サイズ作成
			Vector2 after_size = new Vector2(transform.GetComponent<RectTransform>().sizeDelta.x, transform.GetComponent<TMP_InputField>().pointSize * lineCount + SPACE);
			//サイズ変更
			transform.GetComponent<RectTransform>().sizeDelta = after_size;
			foreach (Transform item in parent_control_pos_obj)
			{
				RectTransform item_rect = item.GetComponent<RectTransform>();
				item_rect.offsetMax = new Vector2(0f, 0f);
				item_rect.offsetMin = new Vector2(0f, 0f);
			}
		}
	}
}
