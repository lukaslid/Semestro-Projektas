using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {

    public Rigidbody2D projectilePrefab;
    public float fireRate;
    public float projectileSpeed;

    public int bulletCount, maxAmmo;
    public Text bulletText;
    

    private Transform firePoint;
    private float cooldown;
    private bool canShoot;
    Color red, black, color;
    private Animator anim;

    private void Awake()
    {
        red = new Color(255, 0, 0);
        black = new Color(0, 0, 0);
        maxAmmo = bulletCount;
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
            Debug.LogError("No FirePoint");
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        color = black;
        SetBulletText(color);
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > cooldown)
        {
            if (bulletCount > 0 && canShoot)
            {
                color = black;
                cooldown = Time.time + (1 / fireRate);
                bulletCount--;
                Fire();
            }
            else
            {
                color = red;
                canShoot = false;
                StartCoroutine(reload());
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            canShoot = false;
            color = red;
            StartCoroutine(reload());
        }
        SetBulletText(color);
    }

    IEnumerator reload()
    {
        anim.SetBool("isAmmoEmpty", true);
        yield return new WaitForSeconds(0.55f);
        anim.SetBool("isAmmoEmpty", false);
        yield return new WaitForSeconds(0.2f);
        bulletCount = 50;
        canShoot = true;
    }

    void Fire()
    {
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        Rigidbody2D projectile = Instantiate(projectilePrefab, firePointPosition, firePoint.rotation);
        projectile.AddForce(transform.up * projectileSpeed);
    }

    void SetBulletText(Color color)
    {
        bulletText.color = color;
        bulletText.text = bulletCount + "/" + maxAmmo;
    }
}
