using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {

    public Rigidbody2D projectilePrefab;
    public float fireRate;
    public float projectileSpeed;
    private Transform firePoint;
    private float cooldown;

    //Bullet management and reloading
    private int bulletCount;
    public int bulletMax;
    public Text bulletText;
    private bool isReloading = false;
    private Animator anim;

    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
            Debug.LogError("No FirePoint");
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        bulletCount = bulletMax;
        SetBulletText();
    }

    //For future implementations (Weapon swap)
    //private void OnEnable()
    //{
    //    isReloading = false;
    //    anim.SetBool("isAmmoEmpty", false);
    //}

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (bulletCount <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time > cooldown)
        {
            cooldown = Time.time + (1 / fireRate);
            bulletCount--;
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletCount != bulletMax)
        {
            StartCoroutine(Reload());
            return;
        }
        SetBulletText();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        anim.SetBool("isAmmoEmpty", true);
        yield return new WaitForSeconds(0.55f);
        anim.SetBool("isAmmoEmpty", false);
        bulletCount = bulletMax;
        SetBulletText();
        yield return new WaitForSeconds(0.25f);        
        isReloading = false;   
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
