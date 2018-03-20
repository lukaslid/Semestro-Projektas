﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
	
	public enum SpawnState {SPAWNING, WAITING, COUNTING };

	//define wave
	[System.Serializable]
	public class Wave
	{
		//public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

	public float timeBetweenWaves = 5f;
	public float waveCountdown;

	private SpawnState state = SpawnState.COUNTING;

	// Use this for initialization
	void Start () {
		waveCountdown = timeBetweenWaves;
	}
	
	// Update is called once per frame
	void Update () {
		if (waveCountdown <= 0) {
			if (state == SpawnState.COUNTING) {
				//start spawn
				StartCoroutine( SpawnWave(waves[nextWave]));
			}
		} else {
			waveCountdown -= Time.deltaTime;
		}
			
	}

	IEnumerator SpawnWave (Wave wave) {
		state = SpawnState.SPAWNING;

		for (int i = 0; i < wave.count; i++) {
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1f/wave.rate);
		}
			
		state = SpawnState.WAITING;
		yield break;
	}

	void SpawnEnemy(Transform enemy) {
		Instantiate (enemy, transform.position, transform.rotation);
		Debug.Log ("Spawnig Enemy " + enemy.name);
	}
}