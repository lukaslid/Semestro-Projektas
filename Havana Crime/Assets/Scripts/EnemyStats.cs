using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    void AddEXP(int experience)
    {
        GameObject.Find("Player").GetComponent<PlayerStats>().currentExp += experience;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void Damage(int damage)
    {
        HP -= damage;
        Debug.Log("Did: " + damage);
    }
}
