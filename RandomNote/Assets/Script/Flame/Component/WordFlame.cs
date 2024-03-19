using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using System;

public class WordFlame : MonoBehaviour, I_Flame
{
	[SerializeField]
	private TMP_Text num_text;     //フレーム番号
	[SerializeField]
	private GameObject word;     //単語名
	[SerializeField]
	private GameObject explain;     //説明
	[SerializeField]
	private TMP_Text count_text;     //回数
	[SerializeField]
	private TMP_Text time_text;     //日時
	[SerializeField]
	private GameObject evaluation;     //評価
	[SerializeField]
	private Transform tagPrehub;     //タグプレハブ
	[SerializeField]
	private Transform tagTrans;     //タグ配置場所

	private int flame_num;     //フレーム番号
	private I_FlameData flameData;     //フレームデータ
	private I_TagControl tagControl;     //タグデータ

	/// <summary>
	/// フレーム作成
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void Reflect(int flame_num, I_FlameData flameData, I_TagControl tagControl)
	{
		// データ代入
		this.flame_num = flame_num;
		this.flameData = flameData;
		this.tagControl = tagControl;
		// データ反映
		ReflectData();	// データ反映
		StartCoroutine(ReflectTag());    // タグデータ反映
	}
	/// <summary>
	/// リスナー登録
	/// </summary>
	public void AddListener () {
		//長押し設定
		transform.GetComponent<LongPressControl>().SetLongPressAction( () => {
			GameObject inputpanel = GlobalObjData.Instance.inputPanel;
			// パネル表示
			inputpanel.SetActive(true);
			// フレーム入力プレハブをインスタンスして配置
			// flameDataはコピーして渡す
			inputpanel.GetComponent<InputFlame>().SetFlame(flame_num, flameData.Clone(), tagControl);
			});
	}

	/// <summary>
	/// タグデータ更新
	/// </summary>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectTagUpdate(I_TagControl tagControl)
	{
		this.tagControl = tagControl;
		// サイズ更新のために一旦無効化
		transform.GetComponent<VerticalLayoutGroup>().enabled = false;
		StartCoroutine(ReflectTag());
	}

	/// <summary>
	/// InputFlameに情報を反映
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectInput(int flame_num, I_FlameData flameData, I_TagControl tagControl)
	{
		Reflect(flame_num, flameData, tagControl);
		transform.GetComponent<TagDropDown>().Reflect(flameData, tagControl, ()=>{ ReflectTagUpdate(tagControl); });
	}
	/// <summary>
	/// フレーム新規作成時
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void NewInput(int flame_num, I_TagControl tagControl)
	{
		Reflect(flame_num, new WordData("", 3, "", new List<int>(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")), tagControl);
		transform.GetComponent<TagDropDown>().Reflect(flameData, tagControl, ()=>{ ReflectTagUpdate(tagControl); });
	}

	/// <summary>
	/// フレームデータ取得
	/// </summary>
	/// <returns>フレームデータ</returns>
	public I_FlameData GetFlameData() {
		// データ取得
		((WordData)flameData).word = word.GetComponent<TMP_InputField>().text;
		((WordData)flameData).explain = explain.GetComponent<TMP_InputField>().text;
		if (time_text.text.Length >= 40)
			((WordData)flameData).entry_date = time_text.text[20..39];
		((WordData)flameData).update_date = time_text.text[..18];
		((WordData)flameData).star_num = evaluation.GetComponent<StarComponent>().GetEvaluation();
		// タグは反映されてるのでそのまま
		// データ返却
		return flameData;
	}


	/// <summary>
	/// データ反映のとりまとめ
	/// </summary>
	private void ReflectData () {
		//データ反映
		num_text.text = flame_num.ToString();   //フレーム番号
		ReflectWord();        //単語名
		ReflectExplain();   //説明
		count_text.text = ((WordData)flameData).count.ToString();  //コピー回数
		ReflectDate();  //時間
		ReflectStar();    //星
	}

	//単語名設定
	private void ReflectWord ()
	{
		if (word.GetComponent<TMP_Text>())
			word.GetComponent<TMP_Text>().text = ((WordData)flameData).word;
		else
			word.GetComponent<TMP_InputField>().text = ((WordData)flameData).word;
	}
	//説明文設定
	private void ReflectExplain()
	{
		if (explain.GetComponent<TMP_Text>())
			explain.GetComponent<TMP_Text>().text = ((WordData)flameData).explain;
		else
			explain.GetComponent<TMP_InputField>().text = ((WordData)flameData).explain;

		//高さ調節
		if (explain.GetComponent<ControlTextHeight>())
			explain.GetComponent<ControlTextHeight>().controlTextHeight();
		else
			explain.GetComponent<ControlInputHeight>().control_inputfield_height();
	}

	//時間設定
	private void ReflectDate()
	{
		string update_date = ((WordData)flameData).update_date;
		string entry_date = ((WordData)flameData).entry_date;
		if (update_date == entry_date)
		{
			time_text.text = entry_date;
		}
		else
		{
			time_text.text = update_date + "(" + entry_date + ")";
		}
	}

	//評価設定
	private void ReflectStar()
	{
		short star_num = ((WordData)flameData).star_num;
		evaluation.GetComponent<StarComponent>().ReflectEvaluation(star_num);
	}

	// タグ設定
	private IEnumerator ReflectTag()
	{
		// Destroyが即刻反映されないとかいうクソ仕様だけど、一応念のため
		foreach (Transform child in tagTrans)	{ Destroy(child.gameObject); }
		// Add new tags
		foreach (int tag in ((WordData)flameData).tags)
		{
			tagPrehub.GetComponent<TagComponent>().ReflectData(tagControl.GetName(tag));
			Instantiate(tagPrehub, tagTrans);
		}

		yield return null; // 1フレーム待つ sizeDeltaが更新されるのを待つため
		tagTrans.GetComponent<ControlContentLayout>().ArrangeChildObjects();
		// サイズ変更更新
		transform.GetComponent<VerticalLayoutGroup>().enabled = true;
	}
}
