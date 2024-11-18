using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOverlayScript : MonoBehaviour
{
	[Header("UI Management")]
	[SerializeField] GameObject OverlayToToggle;

	public void ToggleOverlay()
	{
		// Check if overlay does not exist
		if (OverlayToToggle == null)
		{
			return;
		}

		// Switch overlay state
		if (OverlayToToggle.activeInHierarchy == true)
		{
			OverlayToToggle.SetActive(false);
		}
		else if (OverlayToToggle.activeInHierarchy == false)
		{
			OverlayToToggle.SetActive(true);
		}
	}
}
