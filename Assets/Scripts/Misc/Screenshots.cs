using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class Screenshots : MonoBehaviour
	{
		public KeyCode screenKey;
		public string imageName = "ss_";

		int id
		{
			get => PlayerPrefs.GetInt("ssId", 0);
			set => PlayerPrefs.SetInt("ssId", value);
		}

		private void Update()
		{
			if (Input.GetKeyDown(screenKey))
				DoScreenshot();
		}

		void DoScreenshot()
		{
			string name = imageName + string.Format("{0:000}", id);
			ScreenCapture.CaptureScreenshot(name + ".png");
			id++;

			Debug.Log(name + " captured");
		}
	}
}