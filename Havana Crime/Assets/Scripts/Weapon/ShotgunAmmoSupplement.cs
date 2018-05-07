using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoSupplement : MonoBehaviour
{
    public int amount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            //GameObject.Find("Weapon_Shotgun").GetComponent<WeaponScriptShotgun>().AddShotgunAmmo(amount);
            // jeigu ne shotgun rankoje tada crashina
        }
    }
}
