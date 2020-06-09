using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
	/// <summary>
	/// Okno pozwalające sortować wpisy
	/// </summary>
	public class SortWindow : DialogWindow
	{
		[SerializeField] DateDropdown fromDate, toDate;
		[SerializeField] CustomDropdown category;


		private new void Awake()
		{
			onOpened += Clear;
		}

		private void Clear()
		{
			fromDate.date = toDate.date = DateTime.Now;
		}

		public void SortByDate()
		{
			DateTime from = fromDate.date;
			DateTime to = toDate.date;

			CloseWindow();
			MainManager.Instance.SortByDate(from, to);
		}

		public void SortByCategory()
		{
			CloseWindow();
			MainManager.Instance.SortByCategory(category.captionType);
		}
	} 
}
