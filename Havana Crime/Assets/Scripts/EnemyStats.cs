using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public int HP;
    public int DMG;
    public int DEF;
    public float speed;
    public float statModifier;

    private int baseHP = 50;
    private int baseDMG = 10;
    private int baseDEF = 1;

    private void Start()
    {
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
