using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour {

    //Player Stats
    public int currentLevel;
    public int maxLevel;
    public int currentExp;
    public int currentHP;
    public int currentDMG;
    public int currentDEF;
    public float currentSpeed;

    //Level arrays
    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] DMGLevels;
    public int[] DEFLevels;
    public float defaultSpeed;

    private void Start()
    {
        currentHP = 0;
        currentHP = HPLevels[currentLevel - 1];
        currentDMG = DMGLevels[currentLevel - 1];
        currentDEF = DEFLevels[currentLevel - 1];
        currentSpeed = transform.GetComponent<PlayerMobility>().speed;
    }

    private void Update()
    {
        if ((currentLevel + 1) <= maxLevel && currentExp >= toLevelUp[currentLevel])
        {
            SetLevel(currentLevel + 1);
        }

        if (currentHP <= 0) Die();
    }

    public void Die()
    {
        SceneManager.LoadScene(1);
    }
    public void SetLevel(int level)
    {
        currentLevel = level;
        currentHP = HPLevels[currentLevel - 1];
        currentDMG = DMGLevels[currentLevel - 1];
        currentDEF = DEFLevels[currentLevel - 1];
    }

    
}
