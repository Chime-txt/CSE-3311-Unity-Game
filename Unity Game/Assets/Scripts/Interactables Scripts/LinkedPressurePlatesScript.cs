using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedPressurePlatesScript : MonoBehaviour
{
    // This script can link two different pressure plates together via a counter.

    private int noPlayersOnPressurePlate;

	public void Start()
	{
        noPlayersOnPressurePlate = 0;
	}

    // Add the number of players standing on the linked pressure plates
	public int addToNoPlayers()
    {
        noPlayersOnPressurePlate++;
		return noPlayersOnPressurePlate;
    }

	// Subtract the number of players standing on the linked pressure plates
	public int subToNoPlayers()
    {
        noPlayersOnPressurePlate--;
		return noPlayersOnPressurePlate;
	}
}
