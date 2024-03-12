using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


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
	private Transform tag_space;     //タグ配置場所

	private WordData wordData;     //単語データ
	private I_TagControl tagControl;     //タグコントローラ

	/// <summary>
	/// フレーム作成
	/// </summary>
	/// <param name="flame_num">フレーム番号</param>
	/// <param name="flameData">フレームデータ</param>
	/// <param name="tagControl">タグデータ</param>
	public void ReflectData(int flame_num, I_FlameData flameData, I_TagControl tagControl)
	{
		wordData = (WordData)flameData;
		this.tagControl = tagControl;
		//データ代入
		num_text.text = flame_num.ToString();   //フレーム番号
		word_text.text = wordData.word;          //単語名
		set_explain();   //説明
		count_text.text = wordData.count.ToString();  //コピー回数
		set_date();  //時間
		set_star();    //星
		set_tag();    //タグ
	}

	//説明文設定
	private void set_explain()
	{
		explain_text.text = wordData.explain;
		explain_text.GetComponent<ControlTextHeight>().controlTextHeight(); //高さ調節
	}

	//時間設定
	private void set_date()
	{
		string update_date = wordData.update_date;
		string entry_date = wordData.entry_date;
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
	private void set_star()
	{
		int star_num = wordData.star_num;
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
	private void set_tag()
	{
		tag_space.GetComponent<ControlContentLayout>().SetTags(wordData.tags, tagControl);
	}
}
