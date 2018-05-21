using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{

    public float moveSpeed;
    public int damage;
    public TextMesh text;
    

    public void Update()
    {
        //damage = GameObject.Find("Player").GetComponent<PlayerStats>().currentDMG;
        //text.text = damage.ToString();
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, (moveSpeed * Time.deltaTime));
    }
}

