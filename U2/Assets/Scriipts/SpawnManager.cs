using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    float orientation;
    float initialSpawnTimer = 1.0f;
    float spawnTimer;
    Quaternion rotation = Quaternion.Euler(0, 90, 0);
    Quaternion rotation2 = Quaternion.Euler(0, 270, 0);
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = initialSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        orientation = Random.Range(1, 3);
        initialSpawnTimer -= 0.005f * Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0 && orientation == 1)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-15, 15), 0, 20), animalPrefabs[animalIndex].transform.rotation);
            spawnTimer = initialSpawnTimer;
        }
        else if (spawnTimer < 0 && orientation == 2)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], new Vector3(-25, 0, Random.Range(-2,15)), rotation);
            spawnTimer = initialSpawnTimer;
        }
        else if (spawnTimer < 0 && orientation == 3)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], new Vector3(25, 0, Random.Range(-2, 15)), rotation2);
            spawnTimer = initialSpawnTimer;
        }
    }
}
