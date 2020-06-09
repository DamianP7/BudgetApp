using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
	/// <summary>
	/// Klasa wyświetlająca wpis
	/// </summary>
	public class ItemPanel : MonoBehaviour
	{
		[SerializeField] Text itemName;
		[SerializeField] Text itemCost;
		[SerializeField] Text itemCategory;
		[SerializeField] Text itemDate;
		[SerializeField] ScrollRect scrollRect;

		private new string name;
		private float cost;
		private Categories category;
		private DateTime date;
		private int id;

		public string Name
		{
			get => name;
			set
			{
				name = value;
				itemName.text = name;
			}
		}
		public float Cost
		{
			get => cost;
			set
			{
				cost = value;
				itemCost.text = string.Format("{0:0.00}", cost);
			}
		}
		public Categories Category
		{
			get => category;
			set
			{
				category = value;
				itemCategory.text = category.ToString();
			}
		}
		public DateTime Date
		{
			get => date;
			set
			{
				date = value;
				itemDate.text = date.ToEuropeanString();
			}
		}
		public int Id
		{
			get => id;
			set => id = value;
		}

		public void ScrollMoved(Vector2 vector2)
		{
			if (vector2.x < 0.1f || vector2.x > 0.9f)
				MainPanel.Instance.OpenEditPanel(id, new Item(name, cost, category, date));
		}

		public void Refresh()
		{
			scrollRect.horizontalNormalizedPosition = 0.5f;
		}
	}
}
