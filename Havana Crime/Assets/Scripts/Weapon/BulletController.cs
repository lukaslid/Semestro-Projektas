using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float destroyTimer;
    public bool destroyOnCollision = true;


    void Update()
    {
        Destroy(this.gameObject, destroyTimer);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Untagged")
        {
            if (destroyOnCollision)
                Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Enemy")
        {
            if (destroyOnCollision)
                Destroy(this.gameObject);

            coll.gameObject.GetComponent<EnemyStats>().Damage(GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Untagged")
        {
            if (destroyOnCollision)
                Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Enemy")
        {
            if (destroyOnCollision)
                Destroy(this.gameObject);

            coll.gameObject.GetComponent<EnemyStats>().Damage(GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG);
        }
    }
}
