using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorTriggerZone : MonoBehaviour {

    public bool isDamaging;
    public float damage = 10;
    public float speedChange;
    private float defaultSpeed;
    public GameObject player;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
            player.GetComponent<PlayerMobility>().ChangeSpeed(speedChange);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.GetComponent<PlayerMobility>().ChangeSpeed(0);
        }
    }




}
