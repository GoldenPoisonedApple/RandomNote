using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TagTest
{
	[Test]
	public void InitTest()
	{
		I_TagControl tagControl = new TagDataWrapper();
		Assert.AreEqual(0, tagControl.GetTagCount());
	}

	[Test]
	public void AddTest()
	{
		// Arrange
		I_TagControl tagControl = new TagDataWrapper();
		// Act
		tagControl.AddTag("test");
		// Assert
		Assert.AreEqual(1, tagControl.GetTagCount());
		Assert.AreEqual("test", tagControl.GetName(0));
		Assert.AreEqual(0, tagControl.GetAmount(0));

		// Arrange
		tagControl = new TagDataWrapper();
		// Act
		tagControl.AddTag("test", 20);
		// Assert
		Assert.AreEqual(1, tagControl.GetTagCount());
		Assert.AreEqual("test", tagControl.GetName(0));
		Assert.AreEqual(20, tagControl.GetAmount(0));

		// Arrange
		TagDataWrapper tagDataWrapper = new TagDataWrapper();
		List<TagData> list = new List<TagData>();
		list.Add(new TagData(0, "first"));
		list.Add(new TagData(1, "second"));
		tagDataWrapper.tagDatas = list;
		// Act
		tagDataWrapper.AddTag("test");
		// Assert
		Assert.AreEqual("test", tagDataWrapper.GetName(2));
	}

	[Test]
	public void UpdateNameTest () {
		// Arrange
		I_TagControl tagControl = new TagDataWrapper();
		tagControl.AddTag("before");
		// Act
		tagControl.UpdateName(0, "after");
		// Assert
		Assert.AreEqual("after", tagControl.GetName(0));
	}

	[Test]
	public void IncrementTest () {
		// Arrange
		I_TagControl tagControl = new TagDataWrapper();
		tagControl.AddTag("test", 19);
		// Act
		tagControl.Increment(0);
		// Assert
		Assert.AreEqual(20, tagControl.GetAmount(0));
	}

	[Test]
	public void UpdateAmountTest () {
		// Arrange
		I_TagControl tagControl = new TagDataWrapper();
		tagControl.AddTag("test");
		// Act
		tagControl.UpdateAmount(0, 20);
		// Assert
		Assert.AreEqual(20, tagControl.GetAmount(0));
	}

	[Test]
	public void DelTagTest () {
		// Arrange
		I_TagControl tagControl = new TagDataWrapper();
		tagControl.AddTag("test");
		tagControl.AddTag("test");
		// Act
		tagControl.DelTag(0);
		// Assert
		Assert.AreEqual(1, tagControl.GetTagCount());
	}

	[Test]
	public void ActTest()
	{
		I_TagControl tagLibraryTest = new TagDataWrapper();
		tagLibraryTest.AddTag("1");
		tagLibraryTest.AddTag("2");
		tagLibraryTest.AddTag("3");
		tagLibraryTest.AddTag("4");
		tagLibraryTest.AddTag("5");
		tagLibraryTest.DelTag(4);
		tagLibraryTest.DelTag(2);
		tagLibraryTest.AddTag("6");
		tagLibraryTest.AddTag("7");
		tagLibraryTest.DelTag(1);
		tagLibraryTest.DelTag(3);
		tagLibraryTest.AddTag("8");
		tagLibraryTest.AddTag("9");
		tagLibraryTest.AddTag("10");

		List<TagData> tagDatas = tagLibraryTest.GetDatas();
		Assert.AreEqual("1", tagDatas[0].name);
		Assert.AreEqual("8", tagDatas[1].name);
		Assert.AreEqual("6", tagDatas[2].name);
		Assert.AreEqual("9", tagDatas[3].name);
		Assert.AreEqual("7", tagDatas[4].name);
		Assert.AreEqual("10", tagDatas[5].name);
		Assert.AreEqual(6, tagDatas.Count);
	}
}
