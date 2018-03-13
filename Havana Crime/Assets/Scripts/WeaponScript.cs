﻿using System.Collections;
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

    private void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
            Debug.LogError("No FirePoint");
    }

    private void Start()
    {
        bulletCount = 0;
        SetBulletText();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > cooldown)
        {
            if (bulletCount > 0)
            {
                bulletCount--;
                cooldown = Time.time + (1 / fireRate);
                Fire();
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 50;
        }
        SetBulletText();
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
