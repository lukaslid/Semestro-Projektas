using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    public float speed;
    public float time;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject, 0.2f);
            col.SendMessage("SpeedBoostF", new float[]{ speed, time });
        }
    }
}
