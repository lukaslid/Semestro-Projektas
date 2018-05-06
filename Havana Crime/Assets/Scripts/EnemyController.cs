using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb;
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

	}
	void FixedUpdate() {
		rb.velocity = (transform.forward * movementSpeed);
	}
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (transform.position, player.transform.position);
		Debug.Log (distance);

		if (distance > range) {
			// move
			Vector3 targetDir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(targetDir.y,targetDir.x) * Mathf.Rad2Deg - 90f;
			Quaternion q = Quaternion.AngleAxis(angle,Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation,q,180);
			transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
			timeleft = 0.5f;
		}
		else {
			//attack
			timeleft -= Time.deltaTime;
			if (timeleft <= 0.0f) 
			{
				player.GetComponent<HealthBar> ().TakeDamage (100f);
				timeleft = 1.5f;
			}
		}
	}
}
