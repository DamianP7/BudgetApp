using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : Singleton<MainPanel>
{
	[SerializeField] NewItemPanel newItemPanel;
	[SerializeField] SortWindow sortWindow;
	[SerializeField] EditWindow editWindow;


	public void OpenNewItemPanel()
	{
		if (!newItemPanel.isOpened)
			newItemPanel.OpenWindow();
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
