using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public GameObject[] items;
    public GameObject[] obstacles;
    public Vector2 spawnArea;
    private float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public bool SpawnPermission = true;

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

            if (CheckPosition(spawnPosition))
            {
                Instantiate(items[randItem], spawnPosition, gameObject.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    public bool CheckPosition(Vector3 spawnPosition)
    {
        spawnPosition = new Vector3(4, -6, 0);
        bool permission = true;
        for (int i = 0; i < obstacles.Length-1; i++)
        {
            Debug.Log(obstacles[i].GetComponent<BoxCollider2D>().bounds);
            Debug.Log(spawnPosition+ "positionnnnnnnnnn");
            if (obstacles[i].GetComponent<BoxCollider2D>().bounds.Contains(spawnPosition))
            {
                print("point is inside collider");
                permission = false;
                Debug.Log("duoda false");
            }
        }
        return true;
    }
}
