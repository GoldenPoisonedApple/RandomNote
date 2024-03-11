using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
	[Serializable]
	public class FileData : I_FileContent {
		public FileData () {
			constractTest = itemWrapper;
		}
		public ItemWrapper itemWrapper = new ItemWrapper();
		public void Save() {
			FileManager fileManager = new FileManager("test", FileManager.PathType.NAME);
			fileManager.Save(this);
		}

		private ItemWrapper constractTest;
		public ItemWrapper GetItemWrapper() {
			return constractTest;
		}

	}
	[Serializable]
	public class ItemWrapper {
		public List<Item> items = new List<Item>();
	}
	[Serializable]
	public class Item {
		public Item (int num) {
			this.num = num;
		}
		public int num = 0;
	}

	[Test]
	public void LoadTest()
	{
		// Arrange
		FileData fileData = new FileData();
		ItemWrapper itemWrapper = new ItemWrapper();
		itemWrapper.items = new List<Item> {new Item(5), new Item(2), new Item(3)};
		fileData.itemWrapper = itemWrapper;
		fileData.Save();
		FileManager fileManager = new FileManager("test", FileManager.PathType.NAME);
		// Act
		FileData fileData1 = fileManager.Load<FileData>();
		ItemWrapper itemWrapper1 = fileData1.GetItemWrapper();
		// Assert
		Assert.AreEqual(3, fileData1.itemWrapper.items.Count);
		Assert.AreEqual(3, itemWrapper1.items.Count);
		itemWrapper1.items.Add(new Item(10));
		Assert.AreEqual(4, fileData1.itemWrapper.items.Count);
		Assert.AreEqual(4, itemWrapper1.items.Count);
		//object.ReferenceEquals(baseObj, derivedObj)
	}

	[Test]
	public void RefTest1 () {
		List<int> list1 = new List<int>(){1, 9, 3};
		List<int> list2 = list1;

		list2.Add(5);

		Assert.AreEqual(4, list1.Count);
		Assert.AreEqual(4, list2.Count);
	}

	[Test]
	public void RefTest2 () {
		List<int> list1 = new List<int>(){1, 9, 3};
		List<int> list2 = list1;
		list1 = new List<int>{2, 4};

		list2.Add(5);

		Assert.AreEqual(2, list1.Count);
		Assert.AreEqual(4, list2.Count);
	}
}
