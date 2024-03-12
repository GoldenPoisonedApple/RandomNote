using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FileTest {
	public FileTest () {
		FileData fileData = new FileData(path);
		fileData.tagDatas.AddTag("Tag0");
		fileData.tagDatas.AddTag("Tag1");
		fileData.tagDatas.AddTag("Tag2");
		fileData.tagDatas.AddTag("Tag3");
		fileData.tagDatas.AddTag("Tag4");
		fileData.tagDatas.DelTag(4);
		fileData.Add(new WordData("0", 0, "explain", new List<int>{0, 2}, "2022/02/03"));
		fileData.Add(new WordData("1", 0, "explain", new List<int>{0, 2}, "2022/02/03"));
		fileData.Add(new WordData("2", 0, "explain", new List<int>{0, 2}, "2022/02/03"));
		fileData.Add(new WordData("3", 0, "explain", new List<int>{0, 2}, "2022/02/03"));
		fileData.Add(new WordData("4", 0, "explain", new List<int>{0, 2}, "2022/02/03"));
		fileData.Del(3);
		((I_FileContent)fileData).Save();
	}

	private const string path = "FileTest";

	[Test]
	public void InitTest () {

	}

	[Test]
	public void ActTest () {
		// Arrange
		I_FileContent fileContent = new FileManager(path, FileManager.PathType.NAME).Load<FileData>();
		I_TagControl tagControl = fileContent.GetTagControl();
		List<I_FlameData> flameDatas = fileContent.GetValidDatas();
		// Act
		fileContent.Update(flameDatas[2].GetNum(), new WordData("update_data", 5, "explain", new List<int> {1}, "2024/03/12"));
		fileContent.Add(new WordData("additional_data", 5, "explain", new List<int> {1}, "2024/03/12"));
		fileContent.Del(flameDatas[3].GetNum());
		tagControl.AddTag("new Tag", 199);
		tagControl.Increment(4);
		// Assert
		fileContent.Save();
		// 目視
	}
}