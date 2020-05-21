using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateDropdown : MonoBehaviour
{
	public DateTime date
	{
		get
		{
			Debug.Log(day + "| " + month + " | " + year);
			return new DateTime(year, month, day);
		}
		set
		{
			dayList.value = value.Day - 1;
			monthList.value = value.Month - 1;
			yearList.value = value.Year - 1;
		}
	}

	[Header("Objects")]
	[SerializeField] Dropdown dayList;
	[SerializeField] Dropdown monthList, yearList;

	[Header("Settings")]
	[SerializeField] int minYear = 2019;
	[SerializeField] int maxYear = 2020;

	int day => int.Parse(dayList.captionText.text);
	int month => int.Parse(monthList.captionText.text);
	int year => int.Parse(yearList.captionText.text);

#if UNITY_EDITOR
	private void OnValidate()
	{
		SetYears();
		SetMonths();
		SetDays();
	}
#endif

	private void Awake()
	{
		SetYears();
		SetMonths();
		SetDays();
	}

	#region Setup
	public void Refresh()
	{
		if (day > DateTime.DaysInMonth(year, month))
		{
			SetDays();
			dayList.value = dayList.options.Count;
		}
	}

	void SetDays()
	{
		FillDropdownWithNumbers(dayList, 1, DateTime.DaysInMonth(year, month));
	}

	void SetMonths()
	{
		FillDropdownWithNumbers(monthList, 1, 12);
	}

	void SetYears()
	{
		FillDropdownWithNumbers(yearList, minYear, maxYear);
	}

	void FillDropdownWithNumbers(Dropdown dropdown, int min, int max)
	{
		dropdown.options.Clear();
		string[] categories = Enum.GetNames(typeof(Categories));
		for (int i = min; i <= max; i++)
		{
			dropdown.options.Add(new Dropdown.OptionData(i.ToString()));
		}
	}
	#endregion
}
