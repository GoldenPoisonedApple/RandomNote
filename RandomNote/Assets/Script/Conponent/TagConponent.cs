using UnityEngine;
using TMPro;

public class TagComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text;

	public void ReflectData(string name)
	{
		text.text = name;
	}
}