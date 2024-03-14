using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProcess : MonoBehaviour
{

	[SerializeField]
	private Button testButton;     //テスト発動用ボタン
	private FlameList flameList;	//フレームリスト

	/// <summary>
	/// 読み込んだファイル情報
	/// </summary>
	protected I_FileContent fileContent;

	// Start is called before the first frame update
	void Start()
	{
		//リスナー登録
		testButton.GetComponent<Button>().onClick.AddListener(Test);
		Debug.Log("aaeta");
		flameList = new FlameList(new FlameFactory(I_FileContent.FileType.WORD, "FileTest", false));
	}

	/// <summary>
	/// テスト
	/// </summary>
	private void Test () {
		flameList.Test();
	}
}
