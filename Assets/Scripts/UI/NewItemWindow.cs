using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
	/// <summary>
	/// Okno dodawania nowego wpisu
	/// </summary>
	public class NewItemWindow : DialogWindow
	{
		[SerializeField] InputField itemName;
		[SerializeField] InputField itemCost;
		[SerializeField] CustomDropdown itemCategory;
		[SerializeField] DateDropdown itemDate;

		Color placeholderColor;

		private new void Awake()
		{
			base.Awake();
			onOpened += Clear;
			placeholderColor = itemName.placeholder.color;
		}

		private void Clear()
		{
			itemName.placeholder.color = placeholderColor;
			itemName.text = "";
			itemCost.placeholder.color = placeholderColor;
			itemCost.text = "";
			itemDate.date = DateTime.Now;
		}

		public void AddItem()
		{
			if (itemName.text == "")
			{
				itemName.placeholder.color = Color.red;
				return;
			}
			if (itemCost.text == "")
			{
				itemCost.placeholder.color = Color.red;
				return;
			}
			Item item = new Item();
			item.name = itemName.text;
			item.cost = float.Parse(string.Format("{0:0.00}", itemCost.text.Replace(',', '.')));
			item.category = itemCategory.captionType;
			item.date = itemDate.date;

			MainManager.Instance.AddItem(item);
			CloseWindow();
		}

	} 
}
