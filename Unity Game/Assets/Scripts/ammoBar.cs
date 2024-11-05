using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBar : MonoBehaviour
{
    public Slider slider;

	// Get the Ammo Bar component
	void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Set the ammo amount on the ammo bar based on the number of bullets left
	public void SetAmmo(int ammo)
    {
        if (slider != null)
            slider.value = ammo;
    }

    // Set the maximum number of ammo for the slider
	public void SetMaxAmmo(int ammo)
    {
        if (slider != null)
        {
            slider.maxValue = ammo;
            slider.value = ammo;
        }
    }
}
