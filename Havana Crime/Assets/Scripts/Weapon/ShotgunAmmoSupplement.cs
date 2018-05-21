using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoSupplement : MonoBehaviour
{
    public int amount;
    public GameObject shotgun;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //shotgun = GameObject.Find("Weapon_Shotgun");
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            shotgun.GetComponent<WeaponScriptShotgun>().bulletMax += amount;
        }
    }
}
