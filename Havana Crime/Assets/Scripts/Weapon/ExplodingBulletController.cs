using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBulletController : MonoBehaviour {

    public float destroyTimer;
    public GameObject explosionPrefab;

    void Update()
    {
        Destroy(this.gameObject, destroyTimer);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Untagged" || coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Vector3 collisionPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject explosion = Instantiate(explosionPrefab, collisionPoint, transform.rotation);
        }
    }
}
