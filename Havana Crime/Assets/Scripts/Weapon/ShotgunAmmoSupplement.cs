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
            GameObject.Find("WeaponHolder").transform.GetChild(2).GetComponent<WeaponScriptShotgun>().bulletMax += amount;
        }
    }
}
