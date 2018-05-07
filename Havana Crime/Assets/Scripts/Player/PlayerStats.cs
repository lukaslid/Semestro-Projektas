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

    ////Level arrays
    //public int[] toLevelUp;
    //public int[] HPLevels;
    //public int[] DMGLevels;
    //public int[] DEFLevels;
    //public float defaultSpeed;

    public float expModifier;
    public int toLevel;
    public int baseEXP;

    private void Start()
    {
        //currentHP = 0;
        //currentHP = HPLevels[currentLevel - 1];
        //currentDMG = DMGLevels[currentLevel - 1];
        //currentDEF = DEFLevels[currentLevel - 1];
        //currentSpeed = transform.GetComponent<PlayerMobility>().speed;

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
        //if ((currentLevel + 1) <= maxLevel && currentExp >= toLevelUp[currentLevel])
        //{
        //    SetLevel(currentLevel + 1);
        //}

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

    //public void SetLevel(int level)
    //{
    //    currentLevel = level;
    //    currentHP = HPLevels[currentLevel - 1];
    //    currentDMG = DMGLevels[currentLevel - 1];
    //    currentDEF = DEFLevels[currentLevel - 1];
    //    if (currentLevel % 5 == 0)
    //        charPoints += 5;
    //    else
    //        charPoints += 3;
    //}

    public void LevelUP()
    {
        //Fibbonaci progression
        //int temp = baseEXP;
        //baseEXP = toLevel;
        //toLevel = temp + toLevel;

        toLevel = toLevel + (int)(toLevel * expModifier);
        currentLevel++;
        currentHP += 100;
        currentDMG += 5;
        currentDEF += 3;
        if (currentLevel % 5 == 0)
            charPoints += 5;
        else
            charPoints += 3;
    }

    public void SetCharacteristic(string stat)
    {
        if (charPoints > 0)
        {
            if (stat == "HP")
            {
                currentHP += 5;
                charPoints--;
            }
            if (stat == "DMG")
            {
                currentDMG += 5;
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