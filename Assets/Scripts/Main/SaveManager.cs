using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Manager odpowiedzialny za zapisywanie pliku i wczytywanie danych.
/// </summary>
public class SaveManager : Singleton<SaveManager>
{
	public void Save(List<Item> items)
	{
		FileStream fs = new FileStream("save.dat", FileMode.Create);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(fs, items);
		fs.Close();
	}

	public List<Item> Load()
	{
		if (!File.Exists("save.dat"))
			return new List<Item>();

		List<Item> items;
		using (Stream stream = File.Open("save.dat", FileMode.Open))
		{
			var bformatter = new BinaryFormatter();

			items = (List<Item>)bformatter.Deserialize(stream);
		}
		return items;
	}
}
