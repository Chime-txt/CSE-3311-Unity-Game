using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetAmmo(int ammo)
    {
        slider.value = ammo;
    }
    public void SetMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
