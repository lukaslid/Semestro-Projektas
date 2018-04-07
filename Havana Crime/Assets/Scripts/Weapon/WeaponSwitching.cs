using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;
    public Text currentWeapon;
    public string[] weaponList = { "Rifle", "Pistol", "Shotgun" };

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previouslySelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if(previouslySelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        SetCurrentWeaponText();
    }

    void SetCurrentWeaponText()
    {
        currentWeapon.text = weaponList[selectedWeapon];
    }
}
