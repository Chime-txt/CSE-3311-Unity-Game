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
    //[SerializeField] float bulletLifetime = 5f;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Red")) 
        {
            if (Input.GetKeyDown(KeyCode.S) == true) //If Player Red presses S fires a bullet
            {
                GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                BulletScript bulletScript = bullet.GetComponent<BulletScript>();
                bulletScript.SetPlayer(gameObject);
                //Destroy(bullet, 5f);
            }

        }
        if (gameObject.tag.Equals("Blue"))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) == true) //If Player Blue presses down arrow fires a bullet
            {
                GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                BulletScript bulletScript = bullet.GetComponent<BulletScript>();
                bulletScript.SetPlayer(gameObject);
                //Destroy(bullet, 5f);
            }
        }
    }       
}
