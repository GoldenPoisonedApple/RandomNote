using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class TagDropDown : MonoBehaviour {
	[SerializeField]
	private TMP_Dropdown dropDown;     // ドロップダウン

	private List<TagData> selectableDatas;     // セレクト可能なタグデータ
	private I_FlameData flameData;     // フレームデータ
	private I_TagControl tagControl;     // タグデータ

	public void Reflect (I_FlameData flameData, I_TagControl tagControl, Action action) {
		// データ代入
		this.flameData = flameData;
		this.tagControl = tagControl;
		// タグデータ反映
		ControlData();

		// リスナー登録
		dropDown.onValueChanged.AddListener( (int value) => {
			// 一番最後のやつは何もしない
			if (value < selectableDatas.Count) {
				// タグ追加
				flameData.GetTags().Add(selectableDatas[value].num);
				// タグ削除
				ControlData();
				// タグデータ反映
				action();
			}
		});
	}

	private void ControlData () {
		// ドロップダウンデータ反映
		dropDown.ClearOptions();
		// セレクト可能なタグを選別
		List<int> tags = flameData.GetTags();
		selectableDatas = tagControl.GetValidDatas().FindAll(tag => !tags.Contains(tag.num));
		for (int i=0; i<selectableDatas.Count; i++)
		{
			dropDown.options.Add(new TMP_Dropdown.OptionData { text = selectableDatas[i].name });
		}
		// 選択済みだと選択できないので常に選択されてる最後のやつを追加
		dropDown.options.Add(new TMP_Dropdown.OptionData { text = "" });
		dropDown.value = selectableDatas.Count;
	}
}