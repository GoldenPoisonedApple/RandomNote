using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class C_InputTag : MonoBehaviour, I_TagComponent
{
	[SerializeField]
	private TMP_Text text;
	[SerializeField]
	private Button button;

	public void ReflectData(TagData tagData, I_FlameData flameData)
	{
		// テキストにタグ名を代入
		text.text = tagData.name;
		// ボタンにリスナー登録
		button.onClick.AddListener(OnClickButton);
	}

	private void OnClickButton()
	{
		Debug.Log(text.text + "をコピーしました");
	}
}