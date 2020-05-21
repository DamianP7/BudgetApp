using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class DialogWindow : MonoBehaviour
{
	public bool isOpened
	{
		get
		{
			if (canvasGroup == null)
				canvasGroup = GetComponent<CanvasGroup>();
			return canvasGroup.alpha == 1;
		}
		set
		{
			if (canvasGroup == null)
				canvasGroup = GetComponent<CanvasGroup>();
			canvasGroup.alpha = value ? 1 : 0;
			canvasGroup.interactable = value;
			canvasGroup.blocksRaycasts = value;
		}
	}

	[Tooltip("Set true to show window in scene view")]
	[SerializeField] protected bool isInitialOpened = false;

	protected CanvasGroup canvasGroup;

	protected Action onOpened, onClosed;

#if UNITY_EDITOR
	private void OnValidate()
	{
		CanvasGroup canvas = GetComponent<CanvasGroup>();
		canvas.alpha = isInitialOpened ? 1 : 0;
		canvas.interactable = isInitialOpened;
		canvas.blocksRaycasts = isInitialOpened;
	}
#endif

	protected void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		isOpened = isInitialOpened;
	}

	public void OpenWindow()
	{
		isOpened = true;
		if(onOpened != null) onOpened.Invoke();
	}

	public void CloseWindow()
	{
		isOpened = false;
		if (onClosed != null) onClosed.Invoke();
	}
}
