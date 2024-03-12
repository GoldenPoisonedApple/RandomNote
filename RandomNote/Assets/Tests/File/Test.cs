using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
	private class TestA {
		private int Menber = 0;

		public int GetMenber () {
			return Menber;
		}
		public void SetMenber (int num) {
			Menber = num;
		}
	}


	private TestA funcA (TestA testA) {
		int index = testA.GetMenber();
		testA.SetMenber(index+1);
		return testA;
	}
	private void funcB (List<TestA> list) {
		list.Add(new TestA());
	}

	[Test]
	public void ActTest()
	{
		List<TestA> list = new List<TestA>() {new TestA(), new TestA()};
		Assert.AreEqual(0, list[0].GetMenber());
		Assert.AreEqual(0, list[1].GetMenber());

		funcA(list[0]);
		Assert.AreEqual(1, list[0].GetMenber());
		Assert.AreEqual(0, list[1].GetMenber());
	}

	[Test]
	public void ListAddTest()
	{
		List<TestA> list = new List<TestA>() {new TestA(), new TestA()};
		Assert.AreEqual(2, list.Count);

		funcB(list);

		Assert.AreEqual(3, list.Count);
	}

}
