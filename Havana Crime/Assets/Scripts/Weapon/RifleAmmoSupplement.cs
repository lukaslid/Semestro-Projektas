using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoSupplement : MonoBehaviour
{

    public int amount;
    public GameObject rifle;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //rifle = GameObject.Find("Weapon_Rifle");
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            rifle.GetComponent<WeaponScript>().bulletMax += amount;
        }
    }
}
