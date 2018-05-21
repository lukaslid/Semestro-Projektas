using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

	public Transform enemy;

    private int nextWave = 0;
	public float coefficient;
	private float rate = 1;
	private int count = 1;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private SpawnState state = SpawnState.COUNTING;

    // Use this for initialization
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
		if (state == SpawnState.WAITING) 
		{
			if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) 
			{
				waveCountdown = timeBetweenWaves;
				state = SpawnState.COUNTING;
				nextWave++;
			}
			else 
			{
				return;
			}
		}
        if (waveCountdown <= 0)
        {
            if (state == SpawnState.COUNTING)
            {
				StartCoroutine(SpawnWave());
                UpdateWaveCount();
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    IEnumerator SpawnWave()
    {
        state = SpawnState.SPAWNING;
		count++;
		if (nextWave == 0)
			enemy.GetComponent<EnemyStats> ().statModifier = coefficient;
		else
			enemy.GetComponent<EnemyStats> ().statModifier += 0.2f;
		for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(1f / rate);
        }
        
        state = SpawnState.WAITING;
        yield break;
    }

    public void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, transform.position, transform.rotation);
        Debug.Log("Spawning Enemy " + enemy.name);
		//string count = GameObject.Find("MobCount").GetComponent<TextMeshProUGUI>().text.ToString();
		//int counter = Convert.ToInt32(count);
		//counter++;
		//GameObject.Find("MobCount").GetComponent<TextMeshProUGUI>().SetText(counter.ToString());
    }

    void UpdateWaveCount()
    {
        string wave = GameObject.Find("WaveCount").GetComponent<TextMeshProUGUI>().text;
        double waveCount = Convert.ToDouble(wave);
        waveCount = waveCount + 0.5;
        GameObject.Find("WaveCount").GetComponent<TextMeshProUGUI>().SetText(waveCount.ToString());
    }
}
