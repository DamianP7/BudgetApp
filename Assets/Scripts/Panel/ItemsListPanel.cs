using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

namespace Panel
{
	public class ItemsListPanel : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField] GameObject itemPrefab;

		[Header("Objects")]
		[SerializeField] List<ItemPanel> itemPanels;
		[SerializeField] Transform content;

		int index = 0;

#if UNITY_EDITOR
		private void OnValidate()
		{
			ItemPanel[] items = gameObject.GetComponentsInChildren<ItemPanel>();
			itemPanels = new List<ItemPanel>();
			itemPanels.AddRange(items);
		}
#endif

		public void ClearItems(bool clearAll = false)
		{
			index++;
			if (clearAll)
				index = itemPanels.Count;
			for (int i = 0; i < index; i++)
			{
				itemPanels[i].gameObject.SetActive(false);
			}
			index = 0;
		}

		public void AddItem(int id, Item item)
		{
			AddItem(id, item.name, item.cost, item.category, item.date);
		}

		public void AddItem(int id, string name, float cost, Categories category, DateTime date)
		{
			if (index >= itemPanels.Count)
			{
				GameObject go = Instantiate(itemPrefab, content);
				ItemPanel ip = go.GetComponent<ItemPanel>();
				itemPanels.Add(ip);
			}
			else
				itemPanels[index].gameObject.SetActive(true);

			itemPanels[index].Name = name;
			itemPanels[index].Cost = cost;
			itemPanels[index].Category = category;
			itemPanels[index].Date = date;
			itemPanels[index].Id = id;
			itemPanels[index].Refresh();

			index++;
		}
	} 
}
