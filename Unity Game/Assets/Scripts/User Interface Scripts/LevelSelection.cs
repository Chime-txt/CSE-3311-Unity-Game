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
    //void Update()
    //{
    //    // We can make this function into a button to make it so that the developer can clear the data only at the level select screen
    //    if (Input.GetKeyDown(KeyCode.B)) // USED FOR DEBUGGING PURPOSES
    //        // SHOULD BE DELETED WHEN BUILT
    //    {
    //        PlayerPrefs.DeleteAll();
    //    }
    //}

	// We can make this function into a button to make it so that the user can clear the data only at the level select screen
	public void ResetGameData()
    {
		PlayerPrefs.DeleteAll();
	}
}
