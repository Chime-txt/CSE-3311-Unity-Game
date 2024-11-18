using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOverlayScript : MonoBehaviour
{
	[Header("UI Management")]
	[SerializeField] GameObject Overlay1;
	[SerializeField] GameObject OptionalOverlay2;

	public void ToggleOverlay()
	{
		// Check if overlay does not exist
		if (Overlay1 == null)
		{
			return;
		}

		SwitchActiveState(Overlay1);

		if (OptionalOverlay2 == null)
		{
			return;
		}

		SwitchActiveState(OptionalOverlay2);

		return;
	}

	// Switch between states without knowing which state the overlay is in
	private static void SwitchActiveState(GameObject Overlay)
	{
		// Switch overlay state
		if (Overlay.activeInHierarchy == true)
		{
			Overlay.SetActive(false);
		}
		else if (Overlay.activeInHierarchy == false)
		{
			Overlay.SetActive(true);
		}

		return;
	}

	// Disable any overlay
	public void DisableOverlay(GameObject Overlay)
	{
		if (Overlay == null)
		{
			return;
		}
		Overlay.SetActive(false);
		return;
	}

	// Enable any overlay
	public void EnableOverlay(GameObject Overlay)
	{
		if (Overlay == null)
		{
			return;
		}
		Overlay.SetActive(true);
		return;
	}
}
