using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProcess : MonoBehaviour
{

	/// <summary>
	/// 読み込んだファイル情報
	/// </summary>
	protected I_FileContent fileContent;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("aaeta");
		FlameList flameList = new FlameList(new FlameFactory(I_FileContent.FileType.WORD, "FileTest", false));
	}
}
