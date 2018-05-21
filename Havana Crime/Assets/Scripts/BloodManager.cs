using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodManager : MonoBehaviour {

    public Color flashColor;
    public Image damageImage;
    public float flashSpeed;
    
    public void DamageFlash(bool damaged)
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, Time.deltaTime * flashSpeed);
        }

        GameObject.Find("Player").GetComponent<HealthBar>().damaged = false;
    }
	
}
