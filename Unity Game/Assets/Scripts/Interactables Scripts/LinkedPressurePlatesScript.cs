using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedPressurePlatesScript : MonoBehaviour
{
    // This script can link two different pressure plates together via a counter.
    [SerializeField] GameObject PlateA;
    [SerializeField] GameObject PlateB;

    private int noPlayersOnPressurePlate;

	public void Start()
	{
        noPlayersOnPressurePlate = 0;
	}
	public int addToNoPlayers()
    {
        noPlayersOnPressurePlate++;

		return noPlayersOnPressurePlate;
    }

    public int subToNoPlayers()
    {
        noPlayersOnPressurePlate--;
		return noPlayersOnPressurePlate;
	}
}
