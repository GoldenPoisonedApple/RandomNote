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
}
