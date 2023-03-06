using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    float initialSpawnTimer = 1.0f;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = initialSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        initialSpawnTimer -= 0.005f * Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-15, 15), 0, 20), animalPrefabs[animalIndex].transform.rotation);
            spawnTimer = initialSpawnTimer;
        }
    }
}
