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


	private TestA func (TestA testA) {
		int index = testA.GetMenber();
		testA.SetMenber(index+1);
		return testA;
	}

	[Test]
	public void ActTest()
	{
		List<TestA> list = new List<TestA>() {new TestA(), new TestA()};
		Assert.AreEqual(0, list[0].GetMenber());
		Assert.AreEqual(0, list[1].GetMenber());

		func(list[0]);
		Assert.AreEqual(1, list[0].GetMenber());
		Assert.AreEqual(0, list[1].GetMenber());
	}
}
