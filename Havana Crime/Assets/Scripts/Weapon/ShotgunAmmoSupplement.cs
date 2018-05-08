using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoSupplement : MonoBehaviour
{
    public int amount;
    public GameObject shotgun;

    private void Start()
    {
        shotgun = GameObject.Find("Weapon_Shotgun");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
            shotgun.GetComponent<WeaponScriptShotgun>().bulletMax += 5;
        }
    }
}
