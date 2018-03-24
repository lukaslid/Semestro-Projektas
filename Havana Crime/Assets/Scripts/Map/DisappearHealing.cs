using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearHealing : MonoBehaviour
{
    public float heal;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject, 0.2f);
            col.SendMessage("HealDamage", heal);
        }
    }
}
