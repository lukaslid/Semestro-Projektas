using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{

    //Player Stats
    public int currentLevel;
    public int maxLevel;
    public int currentExp;
    public int currentHP;
    public int currentDMG;
    public int currentDEF;
    public float currentSpeed;
    public int charPoints;

    public float expModifier;
    public int toLevel;
    public int baseEXP;

    private void Start()
    {
        currentLevel = 1;
        baseEXP = 0;
        toLevel = 50;
        currentExp = 0;
        currentHP = 1000;
        currentDMG = 10;
        currentDEF = 0;
        currentSpeed = transform.GetComponent<PlayerMobility>().speed;
    }

    private void Update()
    {
        if(currentExp >= toLevel)
        {
            LevelUP();
        }

        if (currentHP <= 0) Die();
    }

    public void Die()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelUP()
    {

        toLevel = toLevel + (int)(toLevel * expModifier);
        currentLevel++;
        //currentHP += 100;
        //transform.GetComponent<HealthBar>().maxHitpoints += 100;
        //transform.GetComponent<HealthBar>().hitpoints += 100;
        //transform.GetComponent<HealthBar>().UpdateHealthBar();
        //currentDMG += 5;
        //currentDEF += 3;
        if (currentLevel % 5 == 0)
            charPoints += 2;
        else
            charPoints += 1;
    }

    public void SetCharacteristic(string stat)
    {
        if (charPoints > 0)
        {
            if (stat == "HP")
            {
                currentHP += 5;
                charPoints--;
                transform.GetComponent<HealthBar>().UpdateHealthBar();
            }
            if (stat == "DMG")
            {
                currentDMG += 1;
                charPoints--;
            }
            if (stat == "DEF")
            {
                currentDEF += 2;
                charPoints--;
            }
        }
    }
}