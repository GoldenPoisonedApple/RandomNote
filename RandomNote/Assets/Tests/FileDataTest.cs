using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FileDataTest
{
	[Test]
	public void InitTest() {
		// Arrange
		I_FileContent fileContent = new FileData("作成テスト");
		// Act
		fileContent.Save();
		// Assert
		FileManager fileManager = new FileManager("作成テスト", FileManager.PathType.FILE_NAME);
		fileManager.Load<FileData>();
	}

	[Test]
	public void SaveTest()
	{
		// Arrange
		FileData fileData = new FileData("テスト単語集");
		fileData.is_locked = false;
		fileData.wordDatas.Add(new WordData(0, "単語その1", 3, "説明文って難しいよね", new List<int>{1, 5, 7}, "2022/2/1"));
		fileData.wordDatas.Add(new WordData(1, "単語その2", 5, "改行\nとかどうなるんだろう", new List<int> { 7 }, "2022/2/3"));
		I_TagControl tagDataWrapper = new TagDataWrapper();
		tagDataWrapper.AddTag("タグその1", 0);
		tagDataWrapper.AddTag("タグその2", 9);
		tagDataWrapper.AddTag("タグその3", 2);
		tagDataWrapper.AddTag("タグその4", 1);
		tagDataWrapper.AddTag("タグその5", 7);
		tagDataWrapper.AddTag("タグその6", 7);
		tagDataWrapper.DelTag(2);
		tagDataWrapper.DelTag(5);
		tagDataWrapper.AddTag("タグその7", 712);
		tagDataWrapper.AddTag("タグその8", 21);
		tagDataWrapper.AddTag("タグその9", 21);
		fileData.tagDatas = (TagDataWrapper)tagDataWrapper;

		// Act
		((I_FileContent)fileData).Save();

		// Assert
		FileManager fileManager = new FileManager("テスト単語集", FileManager.PathType.FILE_NAME);
		FileData loadData = fileManager.Load<FileData>();
		Assert.AreEqual("タグその1", loadData.tagDatas.GetName(0));
	}
}
