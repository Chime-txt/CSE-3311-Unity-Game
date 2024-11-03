using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;

public class VersionInfoScript : MonoBehaviour
{
    private TMP_Text _versionText;

    // Start is called before the first frame update
    void Start()
    {
        _versionText = GetComponent<TMP_Text>();
        _versionText.text = "Version " + Application.version;
    }
}