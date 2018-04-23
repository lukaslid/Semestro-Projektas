using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb;
	public float movementSpeed;
	public PlayerMobility player;
	public bool reachable;
	public float timeleft = 1.0f;
	public float range = 16;

	// Use this for initialization
	void Start () {
		reachable = false;
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerMobility> ();

	}
	void FixedUpdate() {
		rb.velocity = (transform.forward * movementSpeed);
	}
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (transform.position, player.transform.position);

		if (distance > range) {
			// move
			Vector3 targetDir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(targetDir.y,targetDir.x) * Mathf.Rad2Deg - 90f;
			Quaternion q = Quaternion.AngleAxis(angle,Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation,q,180);
			transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
		}
		else {
			//attack
			if (!reachable) {
				reachable = true;
			} else {
				timeleft -= Time.deltaTime;
			}
			if (timeleft <= 0.0f) 
			{
				//Attack
			}
		}
	}
}
