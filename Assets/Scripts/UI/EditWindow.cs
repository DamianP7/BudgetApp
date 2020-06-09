using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
	/// <summary>
	/// Okno edycji wpisu
	/// </summary>
	public class EditWindow : DialogWindow
	{
		[SerializeField] InputField itemName;
		[SerializeField] InputField itemCost;
		[SerializeField] CustomDropdown itemCategory;
		[SerializeField] DateDropdown itemDate;

		int id;

		public void OpenWindow(int id, Item item)
		{
			itemName.text = item.name;
			itemCost.text = string.Format("{0:0.00}", item.cost);
			itemCategory.value = (int)item.category;
			itemDate.date = item.date;
			this.id = id;

			OpenWindow();
		}

		public void Delete()
		{
			MainManager.Instance.RemoveItem(id);
			CloseWindow();
		}

		public void Save()
		{
			Item item = new Item();
			item.name = itemName.text;
			item.cost = float.Parse(itemCost.text.Replace(',', '.'));
			item.category = itemCategory.captionType;
			item.date = itemDate.date;

			MainManager.Instance.EditItem(id, item);
			CloseWindow();
		}
	} 
}
