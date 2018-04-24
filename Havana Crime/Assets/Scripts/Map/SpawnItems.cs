using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public GameObject[] items;
    public Vector2 spawnArea;
    private float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randItem;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        spawnWait = Random.RandomRange(spawnLeastWait, spawnMostWait);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randItem = Random.RandomRange(0, items.Length);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0);

            Instantiate(items[randItem], spawnPosition, gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);

        }
    }
}
