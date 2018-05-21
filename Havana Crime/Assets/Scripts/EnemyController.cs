using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class EnemyController : MonoBehaviour
{

    private GameObject enemy;
    private Pathfinding.AIPath pathfinding;
    public float movementSpeed;
    public GameObject player;
    public bool reachable;
    public float timeleft = 1.0f;
	public float range;
    public GameObject blood;
    public GameObject groundBlood;
    public GameObject damageText;
    public string monster;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        reachable = false;
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = gameObject;
        pathfinding = enemy.GetComponent<Pathfinding.AIPath>();
        enemy.GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
        GameObject canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
		float distance = Vector3.Distance(transform.position,player.transform.position);
		if (distance.CompareTo(range) == 1)
        {
            // move
            pathfinding.canMove = true;
            timeleft = 0.5f;
            anim.SetBool("attack", false);
        }
        else
        {
            //attack
            pathfinding.canMove = false;
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0f)
            {
                player.GetComponent<HealthBar>().TakeDamage(100f);
                timeleft = 2f;
                anim.SetBool("attack", true);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            //Instantiate(dmgText, transform.position, Quaternion.identity);

            damageText.GetComponent<TextMeshPro>().text = player.GetComponent<PlayerStats>().currentDMG.ToString();
            var x = Instantiate(damageText, transform.position, Quaternion.identity);
            x.transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, (5f * Time.deltaTime));

            //damageText.transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, (1.5f * Time.deltaTime));

            Wait(0.5f);
            Instantiate(groundBlood, transform.position, Quaternion.Euler(0, 0, Random.RandomRange(0, 360)));
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}

