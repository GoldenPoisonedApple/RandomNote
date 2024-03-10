using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WordTest
{
	[Test]
	public void InitTest()
	{
		I_FlameDatas flameDatas = new WordDataWrapper();
		Assert.AreEqual(0, flameDatas.GetFlameCount());
	}

	[Test]
	public void AddTest()
	{
		// 単体
		// Arrange
		I_FlameDatas flameDatas = new WordDataWrapper();
		// Act
		flameDatas.Add(new WordData("test", 4, "fitst", new List<int>{0, 1}, "2020/01/05"));
		// Assert
		Assert.AreEqual(1, flameDatas.GetFlameCount());
		Assert.AreEqual("test", ((WordData)flameDatas.GetFlameDatas()[0]).word);
		Assert.AreEqual(0, ((WordData)flameDatas.GetFlameDatas()[0]).num);

		// 二つ
		// Arrange
		flameDatas = new WordDataWrapper();
		// Act
		flameDatas.Add(new WordData("test1", 4, "fitst", new List<int>{0, 1}, "2020/01/05"));
		flameDatas.Add(new WordData("test2", 4, "second", new List<int>{0, 1}, "2020/01/06"));
		// Assert
		Assert.AreEqual(2, flameDatas.GetFlameCount());
		Assert.AreEqual("test1", ((WordData)flameDatas.GetFlameDatas()[0]).word);
		Assert.AreEqual(0, ((WordData)flameDatas.GetFlameDatas()[0]).num);
		Assert.AreEqual("test2", ((WordData)flameDatas.GetFlameDatas()[1]).word);
		Assert.AreEqual(1, ((WordData)flameDatas.GetFlameDatas()[1]).num);

		// 事前入力
		// Arrange
		flameDatas = new WordDataWrapper();
		WordData wordData1 = new WordData(0, "test1", 4, "fitst", new List<int>{0, 1}, "2020/01/05");
		WordData wordData2 = new WordData(1, "test2", 4, "second", new List<int>{0, 1}, "2020/01/05");
		((WordDataWrapper)flameDatas).wordDatas = new List<WordData>{wordData1, wordData2};

		// Act
		flameDatas.Add(new WordData("test3", 4, "test", new List<int>{0, 1}, "2020/01/05"));
		// Assert
		Assert.AreEqual(3, flameDatas.GetFlameCount());
		Assert.AreEqual("test3", ((WordData)flameDatas.GetFlameDatas()[2]).word);
		Assert.AreEqual(2, ((WordData)flameDatas.GetFlameDatas()[2]).num);

		// 事前入力 DELアリ
		// Arrange
		flameDatas = new WordDataWrapper();
		WordData wordData3 = new WordData(0, "test3", 4, "fitst", new List<int>{0, 1}, "2020/01/05");
		wordData3.status = WordData.DEL;
		((WordDataWrapper)flameDatas).wordDatas = new List<WordData>{wordData1, wordData2, wordData3};

		// Act
		flameDatas.Add(new WordData("test4", 4, "test", new List<int>{0, 1}, "2020/01/05"));
		// Assert
		Assert.AreEqual(3, flameDatas.GetFlameCount());
		Assert.AreEqual("test4", ((WordData)flameDatas.GetFlameDatas()[2]).word);
		Assert.AreEqual(2, ((WordData)flameDatas.GetFlameDatas()[2]).num);
	}

	[Test]
	public void DelTagTest () {
		// 単体
		// Arrange
		I_FlameDatas flameDatas = new WordDataWrapper();
		flameDatas.Add(new WordData("test1", 4, "fitst", new List<int>{0, 1}, "2020/01/05"));
		flameDatas.Add(new WordData("test2", 4, "second", new List<int>{0, 1}, "2020/01/06"));
		// Act
		flameDatas.Del(0);
		// Assert
		Assert.AreEqual(1, flameDatas.GetFlameCount());
		Assert.AreEqual(WordData.DEL, ((WordData)flameDatas.GetFlameDatas()[0]).status);
		Assert.AreEqual(WordData.DATA, ((WordData)flameDatas.GetFlameDatas()[1]).status);
	}

	[Test]
	public void UpdateTest () {
		// 単体
		// Arrange
		I_FlameDatas flameDatas = new WordDataWrapper();
		flameDatas.Add(new WordData("test1", 4, "fitst", new List<int>{0, 1}, "2020/01/05"));
		flameDatas.Add(new WordData("test2", 4, "second", new List<int>{0, 1}, "2020/01/06"));
		// Act
		flameDatas.Update(0, new WordData("test", 4, "test", new List<int>{0, 1}, "2020/01/10"));
		// Assert
		Assert.AreEqual("test", ((WordData)flameDatas.GetFlameDatas()[0]).word);
		Assert.AreEqual("test2", ((WordData)flameDatas.GetFlameDatas()[1]).word);
	}

	[Test]
	public void ActTest()
	{
		// Arrange
		I_FlameDatas flameDatas = new WordDataWrapper();
		WordData wordData1 = new WordData(0, "test1", 4, "fitst", new List<int>{0, 1}, "2020/01/05");
		WordData wordData2 = new WordData(1, "test2", 4, "second", new List<int>{0, 1}, "2020/01/05");
		WordData wordData3 = new WordData(2, "test3", 4, "third", new List<int>{0, 1}, "2020/01/05");
		wordData3.status = WordData.DEL;
		((WordDataWrapper)flameDatas).wordDatas = new List<WordData>{wordData1, wordData2, wordData3};

		// Act
		flameDatas.Add(new WordData("test4", 4, "test", new List<int>{0, 1}, "2020/01/05"));
		flameDatas.Del(0);
		flameDatas.Update(2, new WordData("test4", 4, "test", new List<int>{0, 1}, "2020/01/05"));

		// Assert
		Assert.AreEqual(2, flameDatas.GetFlameCount());
		Assert.AreEqual(WordData.DEL, ((WordData)flameDatas.GetFlameDatas()[0]).status);
		Assert.AreEqual("test2", ((WordData)flameDatas.GetFlameDatas()[1]).word);
		Assert.AreEqual(1, ((WordData)flameDatas.GetFlameDatas()[1]).num);
		Assert.AreEqual("test4", ((WordData)flameDatas.GetFlameDatas()[2]).word);
		Assert.AreEqual(2, ((WordData)flameDatas.GetFlameDatas()[2]).num);
	}
}
