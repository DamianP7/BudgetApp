using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// Lista rozwijana tworzona w z Enuma
/// </summary>
public class CustomDropdown : Dropdown
{
	public Categories captionType
	{
		get
		{
			Categories cat;
			Enum.TryParse(captionText.text, out cat);
			return cat;
		}
	}

	protected override void Start()
	{
		options.Clear();
		string[] categories = System.Enum.GetNames(typeof(Categories));
		foreach (string category in categories)
		{
			options.Add(new OptionData(category));
		}
	}
}
