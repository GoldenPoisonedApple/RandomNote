using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FlameDatasControlTest {
	[Test]
	public void InitTest()
	{
		// Arrange
		List<WordData> wordDatas = new List<WordData>() {
			new WordData(0, "1", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(1, "2", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(2, "3", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(3, "4", 0, "test", new List<int>{0, 1}, "2022/01/05")
			};
		wordDatas[2].SetStatus(I_FlameData.DEL);
		FlameDatasControl<WordData> flameDatasControl = new FlameDatasControl<WordData>(ref wordDatas);
		// Getter Test
		// Act
		// Sssert
		Assert.AreEqual(4, flameDatasControl.GetDatas().Count);
		Assert.AreEqual(3, flameDatasControl.GetValidDatas().Count);
		Assert.AreEqual(3, flameDatasControl.GetValidCount());

		// 参照先と同じである必要がある
		// Act
		wordDatas.Add(new WordData(4, "5", 0, "test", new List<int>{0, 1}, "2022/01/05"));
		// Sssert
		Assert.AreEqual(5, flameDatasControl.GetDatas().Count);
		Assert.AreEqual(4, flameDatasControl.GetValidDatas().Count);
		Assert.AreEqual(4, flameDatasControl.GetValidCount());

		// 取得したデータは参照先と違う必要がある
		// Act
		flameDatasControl.GetDatas().Add(new WordData(5, "6", 0, "test", new List<int>{0, 1}, "2022/01/05"));
		flameDatasControl.GetValidDatas().Add(new WordData(5, "6", 0, "test", new List<int>{0, 1}, "2022/01/05"));
		// Sssert
		Assert.AreEqual(5, flameDatasControl.GetDatas().Count);
		Assert.AreEqual(4, flameDatasControl.GetValidDatas().Count);
		Assert.AreEqual(4, flameDatasControl.GetValidCount());
	}

	[Test]
	public void AddTest()
	{
		// 単体
		// Arrange
		List<WordData> wordDatas = new List<WordData>() {
			new WordData(0, "1", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(1, "2", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(2, "3", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(3, "4", 0, "test", new List<int>{0, 1}, "2022/01/05")
			};
		FlameDatasControl<WordData> flameDatasControl = new FlameDatasControl<WordData>(ref wordDatas);
		// Act
		flameDatasControl.Add(new WordData("5-test", 0, "test", new List<int>{0, 1}, "2020/01/05"));
		// Assert
		Assert.AreEqual(5, flameDatasControl.GetValidCount());
		Assert.AreEqual("5-test", ((WordData)flameDatasControl.GetDatas()[4]).word);
		Assert.AreEqual(4, ((WordData)flameDatasControl.GetDatas()[4]).num);

		// DELデータがあった場合
		// Arrange
		wordDatas[2].SetStatus(I_FlameData.DEL);
		// Act
		flameDatasControl.Add(new WordData("3-test", 0, "test", new List<int>{0, 1}, "2020/01/05"));
		flameDatasControl.Add(new WordData("6-test", 0, "test", new List<int>{0, 1}, "2020/01/05"));
		// Assert
		Assert.AreEqual(6, flameDatasControl.GetValidCount());
		Assert.AreEqual("3-test", ((WordData)flameDatasControl.GetDatas()[2]).word);
		Assert.AreEqual(2, ((WordData)flameDatasControl.GetDatas()[2]).num);
		Assert.AreEqual("6-test", ((WordData)flameDatasControl.GetDatas()[5]).word);
		Assert.AreEqual(5, ((WordData)flameDatasControl.GetDatas()[5]).num);
	}

	[Test]
	public void DelTest () {
		// Arrange
		List<WordData> wordDatas = new List<WordData>() {
			new WordData(0, "1", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(1, "2", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(2, "3", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(3, "4", 0, "test", new List<int>{0, 1}, "2022/01/05")
			};
		FlameDatasControl<WordData> flameDatasControl = new FlameDatasControl<WordData>(ref wordDatas);

		// 途中を削除
		// Act
		flameDatasControl.Del(2);
		// Assert
		Assert.AreEqual(4, flameDatasControl.GetDatas().Count);
		Assert.AreEqual(3, flameDatasControl.GetValidCount());

		// 最後を削除 データが消えるはず
		// Act
		flameDatasControl.Del(3);
		// Assert
		Assert.AreEqual(2, flameDatasControl.GetDatas().Count);
		Assert.AreEqual(2, flameDatasControl.GetValidCount());
	}

	[Test]
	public void UpdateTest () {
		// Arrange
		List<WordData> wordDatas = new List<WordData>() {
			new WordData(0, "1", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(1, "2", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(2, "3", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(3, "4", 0, "test", new List<int>{0, 1}, "2022/01/05")
			};
		FlameDatasControl<WordData> flameDatasControl = new FlameDatasControl<WordData>(ref wordDatas);
		// Act
		flameDatasControl.Update(2, new WordData("test", 0, "test", new List<int>{0, 1}, "2022/01/05"));
		// Assert
		Assert.AreEqual("test", ((WordData)flameDatasControl.GetDatas()[2]).word);
		Assert.AreEqual(2, ((WordData)flameDatasControl.GetDatas()[2]).num);
	}

	[Test]
	public void ActTest()
	{
		// Arrange
		List<WordData> wordDatas = new List<WordData>() {
			new WordData(0, "1", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(1, "2", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(2, "3", 0, "test", new List<int>{0, 1}, "2022/01/05"),
			new WordData(3, "4", 0, "test", new List<int>{0, 1}, "2022/01/05")
			};
		FlameDatasControl<WordData> flameDatasControl = new FlameDatasControl<WordData>(ref wordDatas);

		// Act
		flameDatasControl.Del(2);
		flameDatasControl.Add(new WordData("5", 0, "test", new List<int>{0, 1}, "2020/01/05"));
		flameDatasControl.Add(new WordData("6", 0, "test", new List<int>{0, 1}, "2020/01/05"));

		// Assert
		Assert.AreEqual(5, flameDatasControl.GetValidCount());
		Assert.AreEqual("1", ((WordData)flameDatasControl.GetDatas()[0]).word);
		Assert.AreEqual("2", ((WordData)flameDatasControl.GetDatas()[1]).word);
		Assert.AreEqual("5", ((WordData)flameDatasControl.GetDatas()[2]).word);
		Assert.AreEqual("4", ((WordData)flameDatasControl.GetDatas()[3]).word);
		Assert.AreEqual("6", ((WordData)flameDatasControl.GetDatas()[4]).word);

		for (int i=0; i<5; i++)
			Assert.AreEqual(i, ((WordData)flameDatasControl.GetDatas()[i]).num);
	}
}