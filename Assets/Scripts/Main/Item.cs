using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa przechowująca dane jednego wpisu
/// </summary>
[System.Serializable]
public class Item
{
	public string name;
	public float cost;
	public Categories category;
	public DateTime date;

	public Item() { }
	public Item(string name, float cost, Categories category, DateTime date)
	{
		this.name = name;
		this.cost = cost;
		this.category = category;
		this.date = date;
	}
}
