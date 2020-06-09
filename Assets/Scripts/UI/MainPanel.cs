using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
	/// <summary>
	/// Glowny panel aplikacji
	/// </summary>
	public class MainPanel : Singleton<MainPanel>
	{
		[SerializeField] NewItemWindow newItemWindow;
		[SerializeField] SortWindow sortWindow;
		[SerializeField] EditWindow editWindow;


		public void OpenNewItemPanel()
		{
			if (!newItemWindow.isOpened)
				newItemWindow.OpenWindow();
		}

		public void OpenSortPanel()
		{
			if (!sortWindow.isOpened)
				sortWindow.OpenWindow();
		}

		public void OpenEditPanel(int id, Item item)
		{
			if (!editWindow.isOpened)
				editWindow.OpenWindow(id, item);
		}
	}

}