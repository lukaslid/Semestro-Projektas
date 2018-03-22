using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float destroyTimer;

    void Update()
    {
        Destroy(this.gameObject, destroyTimer);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Untagged" || coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
