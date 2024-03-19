using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameControl : MonoBehaviour
{

	[SerializeField]
	private Button testButton;     //テスト発動用ボタン
	[SerializeField]
	private Button addButton;      //追加ボタン
	[SerializeField]
	private Button returnPanel;      //戻る用パネル



	/// <summary>
	/// 読み込んだファイル情報
	/// </summary>
	private I_FileContent fileContent;

	/// <summary>
	/// デバッグ用
	/// </summary>
	private FlameList flameList;  //フレームリスト

	void Start()
	{
		// フレーム作成
		FlameFactory flameFactory = new FlameFactory(I_FileContent.FileType.WORD, "FileTest", false);
		fileContent = flameFactory.FileContent;
		flameList = new FlameList(flameFactory);

		//リスナー登録
		testButton.GetComponent<Button>().onClick.AddListener(Test);
		//リスナー登録
		addButton.onClick.AddListener(ShowInputPanel);
		returnPanel.onClick.AddListener(CloseInputPanel);
	}

	/// <summary>
	/// フレームデータ追加
	/// </summary>
	/// <param name="flameData">フレームデータ</param>
	public void AddFlame(I_FlameData flameData)
	{
		fileContent.Add(flameData);
		fileContent.Save();
	}

	/// <summary>
	/// フレームデータ削除
	/// </summary>
	/// <param name="index">削除するフレーム保存番号</param>
	public void DelFlame(int index)
	{
		fileContent.Del(index);
		fileContent.Save();
	}

	/// <summary>
	/// フレームデータ更新
	/// </summary>
	/// <param name="index">更新するフレーム保存番号</param>
	/// <param name="flameData">フレームデータ</param>
	public void UpdateFlame(int index, I_FlameData flameData)
	{
		fileContent.Update(index, flameData);
		fileContent.Save();
	}

	// 以下ボタンリスナー関数

	/// <summary>
	/// テスト
	/// </summary>
	private void Test()
	{
		Debug.Log("テスト");
		fileContent.Save();
	}

	/// <summary>
	/// 入力パネル表示
	/// </summary>
	private void ShowInputPanel()
	{
		GameObject inputpanel = GlobalObjData.Instance.inputPanel;
		inputpanel.SetActive(true); // gameObjectをアクティブ化
		inputpanel.GetComponent<InputFlame>().newFlame(fileContent.GetValidCount(), fileContent.GetTagControl());
	}

	/// <summary>
	/// 入力パネル非表示
	/// </summary>
	private void CloseInputPanel()
	{
		GlobalObjData.Instance.inputPanel.SetActive(false); // gameObjectを非アクティブ化
	}
}
