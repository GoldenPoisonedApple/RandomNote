using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TagTest
{
	[Test]
	public void TestSCTilemapExtensionsSimplePasses()
	{
			// Use the Assert class to test conditions
			Assert.That(1, Is.EqualTo(1));  // 追加したテスト項目。 「1 は 1 と同じでしたか？」
	}

	I_TagControl tagLibraryTest = new TagDataWrapper();

	[Test]
	public void Test()
	{
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
