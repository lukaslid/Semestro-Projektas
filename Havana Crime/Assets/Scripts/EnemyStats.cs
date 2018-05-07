using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.IO;

public class EnemyStats : MonoBehaviour {

    public int EXP;
    public int HP;
    public int DMG;
    public int DEF;
    public float speed;
    public float statModifier;

    private int baseHP = 50;
    private int baseDMG = 10;
    private int baseDEF = 1;
    private int baseEXP = 10;

    private void Start()
    {
        EXP = (int)((baseEXP + EXP) * statModifier);
        HP = (int)(baseHP * statModifier);
        DMG = (int)(baseDMG * statModifier);
        DEF = (int)(baseDEF * statModifier);
        speed = transform.GetComponent<EnemyController>().movementSpeed;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Die();
            AddEXP(EXP);
            UpdateScore();
            UpdateCount();
        }
    }

    void AddEXP(int experience)
    {
        GameObject.Find("Player").GetComponent<PlayerStats>().currentExp += experience;
    }

    void UpdateCount()
    {
        string count = GameObject.Find("MobCount").GetComponent<TextMeshProUGUI>().text.ToString();
        int counter = Convert.ToInt32(count);
        counter--;
        GameObject.Find("MobCount").GetComponent<TextMeshProUGUI>().SetText(counter.ToString());
    }

    void UpdateScore()
    {
        string scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text;
        int score = Convert.ToInt32(scoreText);
        score++;
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        if(Convert.ToInt32(GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>().text) < score)
        {
            GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>().SetText(score.ToString());
            File.WriteAllText("highscore.txt", score.ToString());
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void Damage(int damage)
    {
        HP -= damage;
    }
}
