using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10;
    public GameObject player;

    private void OnTriggerStay2D(Collider2D col)
    {
       
        if (col.tag == "Player")
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
    }
}
