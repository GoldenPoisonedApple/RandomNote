using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class WordFlame : MonoBehaviour, I_Flame
{
	[SerializeField]
	private TMP_Text num_text;     //フレーム番号
	[SerializeField]
	private TMP_Text word_text;     //単語名
	[SerializeField]
	private TMP_Text explain_text;     //説明
	[SerializeField]
	private TMP_Text count_text;     //回数
	[SerializeField]
	private TMP_Text time_text;     //日時
	[SerializeField]
	private Image[] stars;     //星
	[SerializeField]
	private Sprite star_on;     //星アリ
	[SerializeField]
	private Sprite star_off;     //星ナシ
	[SerializeField]
	private Transform tagPrehub;     //タグプレハブ
	[SerializeField]
	private Transform tagTrans;     //タグ配置場所

	/// <summary>
	/// フレーム作成
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectData(int flame_num, I_FlameData flameData, I_TagControl tagControl)
	{
		//データ代入
		num_text.text = flame_num.ToString();   //フレーム番号
		word_text.text = ((WordData)flameData).word;          //単語名
		ReflectExplain(flameData);   //説明
		count_text.text = ((WordData)flameData).count.ToString();  //コピー回数
		ReflectDate(flameData);  //時間
		ReflectStar(flameData);    //星
		StartCoroutine(ReflectTag(flameData, tagControl));    //タグ
		//長押し設定
		transform.GetComponent<LongPressControl>().SetLongPressAction( () => {
			GlobalObjData.Instance.inputPanel.SetActive(true);
			});
	}

	/// <summary>
	/// タグデータ更新
	/// </summary>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectTagUpdate(I_FlameData flameData, I_TagControl tagControl)
	{
		// サイズ更新のために一旦無効化
		transform.GetComponent<VerticalLayoutGroup>().enabled = false;
		StartCoroutine(ReflectTag(flameData, tagControl));
	}

	//説明文設定
	private void ReflectExplain(I_FlameData flameData)
	{
		explain_text.text = ((WordData)flameData).explain;
		explain_text.GetComponent<ControlTextHeight>().controlTextHeight(); //高さ調節
	}

	//時間設定
	private void ReflectDate(I_FlameData flameData)
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
	private void ReflectStar(I_FlameData flameData)
	{
		int star_num = ((WordData)flameData).star_num;
		int i = 0;
		//評価の数だけやる
		for (; i < star_num; i++)
		{
			stars[i].sprite = star_on;
		}
		//残りを白にする
		for (; i < stars.Length; i++)
		{
			stars[i].sprite = star_off;
		}
	}

	// タグ設定
	private IEnumerator ReflectTag(I_FlameData flameData, I_TagControl tagControl)
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
