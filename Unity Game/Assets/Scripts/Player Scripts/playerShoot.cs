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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);

            //Destroy(bullet, 5f);
        }
    }       
}
