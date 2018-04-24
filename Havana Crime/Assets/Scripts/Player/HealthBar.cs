using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour
{
    public Image currentHealthBar;
    public Text ratioText;

    private float hitpoints = 1000;
    private float maxHitpoints = 1000;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = hitpoints / maxHitpoints;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;
        if (hitpoints < 0)
        {
            hitpoints = 0;
            Debug.Log("Dead");
        }
        UpdateHealthBar();
    }

    private void HealDamage(float heal)
    {
        hitpoints += heal;
        if(hitpoints > maxHitpoints)
        {
            hitpoints = maxHitpoints;
        }
        UpdateHealthBar();
    }

    private void FixedUpdate()
    {
        if (hitpoints <= 0) SceneManager.LoadScene("EndGame");
    }
}

