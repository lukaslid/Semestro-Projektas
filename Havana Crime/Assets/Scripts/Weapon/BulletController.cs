using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float destroyTimer;
    public bool destroyOnCollision = true;


    void Update()
    {
        Destroy(this.gameObject, destroyTimer);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Untagged")
        {
            if (destroyOnCollision)
                Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Enemy")
        {
            if (destroyOnCollision)
                Destroy(this.gameObject);

            int selectedWeapon = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().selectedWeapon;

            //rifle
            if (selectedWeapon == 0)
            {
                Debug.Log("weapon: " + selectedWeapon);
                coll.gameObject.GetComponent<EnemyStats>().Damage((int)((GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG)
                    * GameObject.Find("Weapon_Rifle").GetComponent<WeaponScript>().damageModifier));
            }
            //pistol
            else if (selectedWeapon == 1)
            {
                Debug.Log("weapon: " + selectedWeapon);
                coll.gameObject.GetComponent<EnemyStats>().Damage((int)((GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG)
                    * GameObject.Find("Weapon_Pistol").GetComponent<WeaponScript>().damageModifier));
            }
            //shotgun
            else if (selectedWeapon == 2)
            {
                Debug.Log("weapon: " + selectedWeapon);
                coll.gameObject.GetComponent<EnemyStats>().Damage((int)((GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG)
                    * GameObject.Find("Weapon_Shotgun").GetComponent<WeaponScriptShotgun>().damageModifier));
                Debug.Log("Did: " + (int)((GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG)
                    * GameObject.Find("Weapon_Shotgun").GetComponent<WeaponScriptShotgun>().damageModifier) + " damage");
            }
        }
    }
}
