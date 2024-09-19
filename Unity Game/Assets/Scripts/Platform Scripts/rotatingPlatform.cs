using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingPlatform : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
