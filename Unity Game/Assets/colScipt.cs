using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class colScipt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI text;
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Entered Area");
        text.text = "Welcome to The BIG HOUSE";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = "";
    }
}
