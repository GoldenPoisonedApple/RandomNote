using UnityEngine;
using TMPro;

public class C_ViewTag : MonoBehaviour, I_TagComponent
{
	[SerializeField]
	private TMP_Text text;

	public void ReflectData(TagData tagData, I_FlameData flameData)
	{
		text.text = tagData.name;
	}
}