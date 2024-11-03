using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
	public Transform shootingPoint;
	public GameObject bulletPrefab;
	public ammoBar ammoBar;
	// [SerializeField] float bulletLifetime = 5f;
	public int AmmoCount = 5;
	public int maxAmmoCount = 5;


    private void Start()
    {
		AmmoCount = maxAmmoCount;
		if (ammoBar != null)
		{
			ammoBar.SetMaxAmmo(maxAmmoCount);
		}
		else
		{
			Debug.LogError("Please attack ammoBar Slider to playerShoot.cs script.");
		}
    }
    // Update is called once per frame
    void Update()
	{
		if (gameObject.tag.Equals("Red")) 
		{
			// If Player Red presses S fires a bullet
			if (Input.GetKeyDown(KeyCode.S) == true) 
			{
				GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
				bulletScript.SetPlayer(gameObject);
                AmmoCount--;
				if (ammoBar)
				{
					ammoBar.SetAmmo(AmmoCount);
				}
                if (AmmoCount == 0)
                {
					enabled = false;
                }
                // Destroy(bullet, 5f);
            }
		}
		if (gameObject.tag.Equals("Blue"))
		{
			// If Player Blue presses down arrow fires a bullet
			if (Input.GetKeyDown(KeyCode.DownArrow) == true)
			{
				GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
                AmmoCount--;
				if (ammoBar)
				{
	                ammoBar.SetAmmo(AmmoCount);
				}
                if (AmmoCount == 0)
                {
                    enabled = false;
                }
                bulletScript.SetPlayer(gameObject);
				// Destroy(bullet, 5f);
			}
		}
	}
}