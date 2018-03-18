using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb;
	public float movementSpeed;
	public PlayerMobility player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerMobility> ();
		
	}
	void FixedUpdate() {
		rb.velocity = (transform.forward * movementSpeed);
	}
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
	}
}
