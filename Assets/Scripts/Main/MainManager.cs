using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interface;

/// <summary>
/// Główna klasa aplikacji.
/// </summary>
public class MainManager : Singleton<MainManager>
{
	[SerializeField] ItemsListPanel listPanel;
	[SerializeField] Text selected;
	[SerializeField] Text totalText;

	List<Item> items;
	List<Item> allItems;
	DateTime Now => DateTime.Now;

	int id = 0;
	float total;

	DateTime savedFrom, savedTo;
	Categories savedCategory;

	Action onRefresh;

	private void Start()
	{
		allItems = SaveManager.Instance.Load();
		items = new List<Item>();
		DateTime start = new DateTime(Now.Year, Now.Month, 1);
		SortByDate(start, Now);
		Refresh();
	}

	public void AddItem(Item item)
	{
		allItems.Add(item);
		items.Add(item);

		SaveManager.Instance.Save(allItems);
		Refresh();
	}

	public void EditItem(int id, Item item)
	{
		allItems.Remove(items[id]);
		items.RemoveAt(id);
		allItems.Add(item);

		SaveManager.Instance.Save(allItems);
		Refresh();
	}

	public void RemoveItem(Item item)
	{
		allItems.Remove(item);

		SaveManager.Instance.Save(allItems);
		Refresh();
	}

	public void RemoveItem(int id)
	{
		allItems.Remove(items[id]);
		items.RemoveAt(id);

		SaveManager.Instance.Save(allItems);
		Refresh();
	}

	public void SortByCategory(Categories category, bool forced = false)
	{
		if (!forced)
		{
			savedCategory = category;
			onRefresh = null;
			onRefresh += SortBySavedCategory;
		}

		items.Clear();
		foreach (var item in allItems)
		{
			if (item.category == category)
				items.Add(item);
		}
		selected.text = "Kat: " + category.ToString();
		Refresh(forced);
	}

	private void SortBySavedCategory()
	{
		SortByCategory(savedCategory, true);
	}

	public void SortByDate(DateTime from, DateTime to, bool forced = false)
	{
		if (!forced)
		{
			savedFrom = from;
			savedTo = to;
			onRefresh = null;
			onRefresh += SortBySavedDate;
		}

		items.Clear();
		foreach (var item in allItems)
		{
			if (DateTime.Compare(item.date, from) >= 0 &&
				DateTime.Compare(item.date, to) <= 0)
				items.Add(item);
		}
		selected.text = from.ToEuropeanShortString() + " - " + to.ToEuropeanShortString();
		Refresh(forced);
	}

	private void SortBySavedDate()
	{
		SortByDate(savedFrom, savedTo, true);
	}

	public void Refresh(bool forced = false)
	{
		id = 0;
		listPanel.ClearItems(true);
		for (int i = 0; i < items.Count; i++)
		{
			listPanel.AddItem(id, items[i]);
			id++;
		}
		if (!forced)
			onRefresh.Invoke();
		SumTotal();
	}

	private void SumTotal()
	{
		total = 0;
		foreach (var item in items)
		{
			total += item.cost;
		}
		totalText.text = (Mathf.RoundToInt(total*100)/100f).ToString();
	}
}
