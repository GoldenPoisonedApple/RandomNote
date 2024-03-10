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
		public ItemWrapper itemWrapper = new ItemWrapper();
		public void Save() {
			FileManager fileManager = new FileManager("test", FileManager.PathType.NAME);
			fileManager.Save(this);
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

	public class ItemWrapperA : ItemWrapper {
		public new List<ItemA> items = new List<ItemA>();
	}
	[Serializable]
	public class ItemA {
		public ItemA (string name) {
			this.name = name;
		}
		public string name;
	}


	[Test]
	public void CommonTest()
	{
		// Arrange
		FileData fileData = new FileData();
		ItemWrapper itemWrapper = new ItemWrapper();
		itemWrapper.items = new List<Item> {new Item(5), new Item(2), new Item(3)};
		fileData.itemWrapper = itemWrapper;
		// Act
		fileData.Save();
		// Assert
	}

	[Test]
	public void ExtendTest()
	{
		// Arrange
		FileData fileData = new FileData();
		ItemWrapperA itemWrapper = new ItemWrapperA();
		itemWrapper.items = new List<ItemA> {new ItemA("1"), new ItemA("name"), new ItemA("test")};
		fileData.itemWrapper = itemWrapper;
		// Act
		fileData.Save();
		// Assert
	}
}
