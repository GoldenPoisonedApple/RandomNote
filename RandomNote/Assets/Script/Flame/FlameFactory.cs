using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFactory
{
	// フレームデータ
	public I_FileContent FileContent { get; private set; }
	// フレームプレハブ
	public GameObject FlamePrehub { get; private set; }
	// ソート系統プレハブ
	public GameObject SortPrehub { get; private set; }
	// フィルタ系統プレハブ
	public GameObject FillterPrehub { get; private set; }



	/// <summary>
	/// フレームに必要なデータ作成
	/// </summary>
	/// <param name="type">フレームの種類</param>
	/// <param name="title">ファイルのタイトル</param>
	/// <param name="is_locked">隠しファイルか</param>
	public FlameFactory(I_FileContent.FileType type, string title, bool is_locked)
	{
		GlobalObjData globalObjData = GlobalObjData.Instance;
		FileManager fileManager = new FileManager(title, is_locked ? FileManager.PathType.HIDDEN_NAME : FileManager.PathType.NAME);
		switch (type)
		{
			case I_FileContent.FileType.FILE_LIST:
				fileFlameFactory(fileManager, globalObjData);
				break;
			case I_FileContent.FileType.WORD:
				wordFlameFactory(fileManager, globalObjData);
				break;
		}
	}

	// ファイルリスト
	private void fileFlameFactory(FileManager fileManager, GlobalObjData globalObjData)
	{
		FileContent = fileManager.Load<FileListDataWrapper>();
		FlamePrehub = globalObjData.getFileFlamePrehub();  //フレームプレハブ割り当て
	}
	// ワード
	private void wordFlameFactory(FileManager fileManager, GlobalObjData globalObjData)
	{
		FileContent = fileManager.Load<FileData>();
		FlamePrehub = globalObjData.getWordFlamePrehub();  //フレームプレハブ割り当て
	}
}
