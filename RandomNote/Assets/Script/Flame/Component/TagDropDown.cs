using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class TagDropDown : MonoBehaviour {
	[SerializeField]
	private TMP_Dropdown dropDown;     // ドロップダウン
	[SerializeField]
	private TMP_InputField inputField;     // インプットフィールド
	[SerializeField]
	private Button createTag;     // インプットフィールド

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
		// ドロップダウン
		dropDown.onValueChanged.AddListener( (int value) => {
			// 一番最後のやつは何もしない
			if (value < selectableDatas.Count) {
				// タグ追加
				flameData.GetTags().Add(selectableDatas[value].num);
				// タグ変更反映
				ControlData();
				// タグデータ反映
				action();
			}
		});
		// インプットフィールド
		inputField.onEndEdit.AddListener( (string value) => {
			ControlData();
		});
		// ボタン
		createTag.onClick.AddListener( () => {
			int tagIndex = tagControl.AddTag(inputField.text);
			// タグ追加
			flameData.GetTags().Add(tagIndex);
			// タグデータ反映
			action();
		});
	}

	private void ControlData () {
		// ドロップダウンデータ反映
		dropDown.ClearOptions();
		// インプットフィールドデータ取得
		string[] searchTexts = inputField.text.Split('　', ' ');
		// セレクト可能なタグを選別
		List<int> tags = flameData.GetTags();
		// 使われてるタグを除外
		selectableDatas = tagControl.GetValidDatas().FindAll(tag => !tags.Contains(tag.num));
		// 検索ワードで絞り込み
		foreach (string searchText in searchTexts) {
			selectableDatas = selectableDatas.FindAll(tag => tag.name.Contains(searchText));
		}
		// ドロップダウンデータ反映
		for (int i=0; i<selectableDatas.Count; i++)
		{
			dropDown.options.Add(new TMP_Dropdown.OptionData { text = selectableDatas[i].name });
		}
		// 選択済みだと選択できないので常に選択されてる最後のやつを追加
		dropDown.options.Add(new TMP_Dropdown.OptionData { text = "" });
		dropDown.value = selectableDatas.Count;
	}
}