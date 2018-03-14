using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {

    public Rigidbody2D projectilePrefab;
    public float fireRate;
    public float projectileSpeed;

    public int bulletCount;
    public Text bulletText;
    

    private Transform firePoint;
    private float cooldown;
    private bool canShoot;

    private Animator anim;

    private void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
            Debug.LogError("No FirePoint");
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        bulletCount = 0;
        SetBulletText();
        canShoot = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > cooldown)
        {
            if (bulletCount > 0 && canShoot)
            {
                cooldown = Time.time + (1 / fireRate);
                bulletCount--;
                Fire();
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
        SetBulletText();
    }

    IEnumerator reload()
    {
        anim.SetBool("isAmmoEmpty", true);
        canShoot = false;
        yield return new WaitForSeconds(0.55f);
        anim.SetBool("isAmmoEmpty", false);
        canShoot = true;
        bulletCount = 5;
        yield return new WaitForSeconds(0.2f);
        
    }

    void Fire()
    {
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        Rigidbody2D projectile = Instantiate(projectilePrefab, firePointPosition, firePoint.rotation);
        projectile.AddForce(transform.up * projectileSpeed);
    }

    void SetBulletText()
    {
        bulletText.text = "Ammo: " + bulletCount;
    }
}
