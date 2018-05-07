using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoSupplement : MonoBehaviour {

    public int amount;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
           //GameObject.Find("Weapon_Rifle").GetComponent<WeaponScript>().AddRifleAmmo(amount);
           // jeigu ne shotgun rankoje tada crashina
        }
    }
}
