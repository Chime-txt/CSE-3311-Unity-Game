using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
	[Header("Player Management")]
	[SerializeField] Transform shootingPoint;
	[SerializeField] Transform playerBullets;

	[Header("UI Management")]
	public ammoBar ammoBar;

	[Header("Bullet")]
	[SerializeField] GameObject bulletPrefab;
	public int AmmoCount = 5;
	public int maxAmmoCount = 5;
	// [SerializeField] float bulletLifetime = 5f;
	// Set a cooldown between when the bullet was first shot and when the player can shoot again
	[SerializeField] float bulletCooldown = 0.3f;

	// Locks the code down when the player shoots a bullet
	[Header("Player Locks")]
	[SerializeField] bool blueLock;
	[SerializeField] bool redLock;

	[Header("Audio Management")]
	[SerializeField] AudioSource audioSource;
	[SerializeField] private AudioClip audioClip;


	private void Start()
    {
		audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
		// Disable the locks for the bullets
		blueLock = false;
		redLock = false;

		AmmoCount = maxAmmoCount;
		if (ammoBar != null)
		{
			ammoBar.SetMaxAmmo(maxAmmoCount);
		}
		else
        {
            Debug.LogError("Please attach ammoBar Slider to playerShoot.cs script.");
        }
    }
    // FixedUpdate is called once every set amount of frames
    void FixedUpdate()
	{
		if (gameObject.tag.Equals("Red")) 
		{
			// If Player Red presses S and their respective lock is not taken, fires a bullet
			if (Input.GetKeyDown(KeyCode.S) == true && redLock == false) 
			{
				// Lock this code down until finished
				redLock = true;
				Debug.Log("Red Player Shoot On Cooldown");

				// Create the bullet using the prefab for the bullet
				GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
				bullet.transform.SetParent(playerBullets, true);
				bullet.name = "Red Bullet";
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
				bulletScript.SetPlayer(gameObject);

				// Reduce the ammo amount and check the ammo bar
				audioSource.PlayOneShot(audioClip);
                AmmoCount--;
				if (ammoBar)
				{
					ammoBar.SetAmmo(AmmoCount);
				}
                if (AmmoCount == 0)
                {
					enabled = false;
					Debug.Log("Red Player Shoot Disabled");
				}
				// Destroy(bullet, 5f);

				// Release the lock and unlock function
				StartCoroutine(ReleaseRedLock());
			}
		}
		if (gameObject.tag.Equals("Blue"))
		{
			// If Player Blue presses down arrow and their respective lock is not taken, fires a bullet 
			if (Input.GetKeyDown(KeyCode.DownArrow) == true && blueLock == false)
			{
				// Lock the function
				blueLock = true;
				Debug.Log("Blue Player Shoot On Cooldown");

				// Create the bullet using the prefab for the bullet
				GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
				bullet.transform.SetParent(playerBullets, true);
				bullet.name = "Blue Bullet";
				BulletScript bulletScript = bullet.GetComponent<BulletScript>();
				bulletScript.SetPlayer(gameObject);

                // Reduce the ammo amount and check the ammo bar
                audioSource.PlayOneShot(audioClip);
                AmmoCount--;
				if (ammoBar)
				{
	                ammoBar.SetAmmo(AmmoCount);
				}
                if (AmmoCount == 0)
                {
                    enabled = false;
					Debug.Log("Blue Player Shoot Disabled");
				}
                bulletScript.SetPlayer(gameObject);
				// Destroy(bullet, 5f);

				// Unlock the function afterwards
				StartCoroutine(ReleaseBlueLock());
			}
		}
	}

	// Release the red lock after time expires
	private IEnumerator ReleaseRedLock()
	{
		// Wait for half a second
		yield return new WaitForSeconds(bulletCooldown);

		// Release the lock
		Debug.Log("Red Player Shoot Available");
		redLock = false;
	}

	// Release the blue lock after time expires
	private IEnumerator ReleaseBlueLock()
	{
		// Wait for half a second
		yield return new WaitForSeconds(bulletCooldown);

		// Release the lock
		Debug.Log("Blue Player Shoot Available");
		blueLock = false;
	}
}