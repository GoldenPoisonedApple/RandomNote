using UnityEngine;
using TMPro;

public class TagDropDown : MonoBehaviour {
	[SerializeField]
	private TMP_Dropdown dropDown;     //ドロップダウン
	
	public void Reflect (I_TagControl tagControl) {
			//ドロップダウン設定
		dropDown.ClearOptions();
		foreach (TagData tagData in tagControl.GetValidDatas())
		{
			dropDown.options.Add(new TMP_Dropdown.OptionData { text = tagData.name });
		}
	}
}