using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    int level1Index = 4;

    // Start is called before the first frame update
    void Start()
    {
        //Set "2" to what Level 1 is in the Build Index
        int levelAt = PlayerPrefs.GetInt("levelAt", 4);

        for (int i = 0; i < lvlButtons.Length; i++)
        {

            if ( i + 4> levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //USED FOR DEBUGGING PURPOSES
            // SHOULD BE DELETED WHEN BUILT
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
