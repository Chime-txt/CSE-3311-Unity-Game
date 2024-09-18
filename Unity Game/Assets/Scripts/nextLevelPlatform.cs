using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isOnRed = false;
    public bool isOnBlue = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag.Equals("RedNext"))
        {
            if (collision.gameObject.tag.Equals("Red"))
            {
                isOnRed = true;
            }
        }
        else if (gameObject.tag.Equals("BlueNext"))
        {
            if (collision.gameObject.tag.Equals("Blue"))
            {
                isOnBlue = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
     if (collision.gameObject.tag.Equals("Red"))
        {
            isOnRed = false;
        }
    if (collision.gameObject.tag.Equals("Blue"))
        {
            isOnBlue = false;
        }

    }
}
