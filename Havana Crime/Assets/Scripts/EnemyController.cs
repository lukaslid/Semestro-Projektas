using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb;
	private GameObject enemy;
	private Pathfinding.AIPath pathfinding;
	public float movementSpeed;
	public GameObject player;
	public bool reachable;
	public float timeleft = 1.0f;
	public float range = 2f;

	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision(this.gameObject.layer, this.gameObject.layer);
		reachable = false;
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = gameObject;
		pathfinding = enemy.GetComponent<Pathfinding.AIPath>();
		enemy.GetComponent<Pathfinding.AIDestinationSetter> ().target = player.transform;
	}

	void FixedUpdate() {
		rb.velocity = (transform.forward * movementSpeed);
	}
	// Update is called once per frame
	void Update () {
		if (! pathfinding.reachedEndOfPath) {
			// move
			pathfinding.canMove = true;
			timeleft = 0.5f;
		}
		else {
			//attack
			pathfinding.canMove = false;
			timeleft -= Time.deltaTime;
			if (timeleft <= 0.0f) 
			{
				player.GetComponent<HealthBar> ().TakeDamage (100f);
				timeleft = 1.5f;
			}
		}
	}
}
