using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoSupplement : MonoBehaviour
{

    public int amount;
    private GameObject rifle;

    private void Start()
    {
        rifle = GameObject.Find("Weapon_Rifle");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            rifle.GetComponent<WeaponScript>().bulletMax += amount;
        }
    }
}
