using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Rigidbody2D projectilePrefab;
    public float fireRate;
    public float projectileSpeed;
    public int bulletCount;

    private Transform firePoint;
    private float cooldown;

    private Animator anim;
    private void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
            Debug.LogError("No FirePoint");
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > cooldown)
        {
            if (bulletCount > 0)
            {
                cooldown = Time.time + (1 / fireRate);
                Fire();
                bulletCount--;
                
            }
            else
            {
                StartCoroutine(reload());
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
        }
    }

    IEnumerator reload()
    {
        anim.SetBool("isAmmoEmpty", true);
        yield return new WaitForSeconds(0.55f);
        anim.SetBool("isAmmoEmpty", false);
        bulletCount = 50;
        
    }

    void Fire()
    {
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        Rigidbody2D projectile = Instantiate(projectilePrefab, firePointPosition, firePoint.rotation);
        projectile.AddForce(transform.up * projectileSpeed);

    }
}
