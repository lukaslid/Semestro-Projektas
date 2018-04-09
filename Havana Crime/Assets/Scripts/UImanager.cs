using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

    public GameObject player;
    public Text playerStats;

    private void Update()
    {
        SetText();

        //Adds +10 EXP
        if (Input.GetKeyDown(KeyCode.T))
        {
            player.GetComponent<PlayerStats>().currentExp += 10;
        }
        //Resets players level to 0
        if (Input.GetKeyDown(KeyCode.Y))
        {
            player.GetComponent<PlayerStats>().SetLevel(1);
            player.GetComponent<PlayerStats>().currentExp = 0;

        }
    }

    void SetText()
    {
        playerStats.text = "LVL: " + player.GetComponent<PlayerStats>().currentLevel + "\n" +
                           "EXP: " + player.GetComponent<PlayerStats>().currentExp + "\n" +
                           "HP: " + player.GetComponent<PlayerStats>().currentHP + "\n" +
                           "DMG: " + player.GetComponent<PlayerStats>().currentDMG + "\n" +
                           "DEF: " + player.GetComponent<PlayerStats>().currentDEF + "\n" +
                           "SPD: " + player.GetComponent<PlayerMobility>().speed + "\n" +
                           "POINTS: " + player.GetComponent<PlayerStats>().points + "\n"; 


    }
}
