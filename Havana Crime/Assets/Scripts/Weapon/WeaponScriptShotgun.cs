using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScriptShotgun : MonoBehaviour {

    public Rigidbody2D projectilePrefab;
    public float fireRate;
    public float projectileSpeed;
    private Transform firePoint;
    private float cooldown;

    //Bullet management and reloading
    public float damageModifier;
    private int bulletCurrent;    //all bullets
    public int bulletMax;       //maximum bullets
    public int bulletCapacity;  //1 round capacity
    public Text bulletText;
    private bool isReloading = false;
    private Animator anim;

    public AudioSource audio;
    public AudioSource reload;

    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
            Debug.LogError("No FirePoint");
        anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        bulletCurrent = bulletCapacity;
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
        SetBulletText();
        if (isReloading)
        {
            return;
        }

        if (bulletCurrent <= 0 && bulletMax > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time > cooldown && bulletCurrent > 0)
        {
            cooldown = Time.time + (1 / fireRate);
            bulletCurrent--;
            anim.SetBool("isShooting", true);
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletCurrent != bulletCapacity && bulletMax > 0)
        {
            StartCoroutine(Reload());
            return;
        }
        SetBulletText();
    }

    private void FixedUpdate()
    {
        if (!Input.GetButton("Fire1")) anim.SetBool("isShooting", false);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reload.Play();
        anim.SetBool("isAmmoEmpty", true);
        yield return new WaitForSeconds(0.55f);
        anim.SetBool("isAmmoEmpty", false);
        if (bulletMax >= bulletCapacity)
        {
            bulletMax -= (bulletCapacity - bulletCurrent);
            bulletCurrent = bulletCapacity;
        }
        else
        {
            if ((bulletMax + bulletCurrent) <= bulletCapacity)
            {
                bulletCurrent = bulletMax;
                bulletMax = 0;                
            }
            else
            {
                bulletMax -= (bulletCapacity - bulletCurrent);
                bulletCurrent += (bulletCapacity - bulletCurrent);
            }
        }
        SetBulletText();
        yield return new WaitForSeconds(0.25f);
        isReloading = false;
    }

    void Fire()
    {
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        Rigidbody2D projectile = Instantiate(projectilePrefab, firePointPosition, firePoint.rotation);
        Rigidbody2D projectile2 = Instantiate(projectilePrefab, firePointPosition, firePoint.rotation);
        Rigidbody2D projectile3 = Instantiate(projectilePrefab, firePointPosition, firePoint.rotation);
        projectile.AddForce(transform.up * projectileSpeed);
        projectile2.AddForce(transform.up * projectileSpeed);
        projectile3.AddForce(transform.up * projectileSpeed);
        audio.Play();
    }

    void SetBulletText()
    {
        bulletText.text = "Ammo: " + bulletCurrent + " / " + bulletCapacity + "\n"
            + "Total ammo: " + bulletMax;
    }

    //public void Upgrade(string stat)
    //{
    //    if (stat == "damage")
    //        damage += 3;
    //    if (stat == "size")
    //        bulletCapacity += 1;
    //}
}
