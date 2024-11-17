using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [TextArea(3,10)] [SerializeField] string text;
    [SerializeField] TextMeshPro _TextMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        _TextMeshPro.text = "";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _TextMeshPro.text = text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
