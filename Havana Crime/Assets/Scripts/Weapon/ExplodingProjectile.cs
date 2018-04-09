using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : MonoBehaviour {

    public Rigidbody2D projectilePrefab;
    public float projectileSpeed;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 firePoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Rigidbody2D molotov = Instantiate(projectilePrefab, firePoint, transform.rotation);
            molotov.AddForce(transform.up * projectileSpeed);
        }
    }
}
