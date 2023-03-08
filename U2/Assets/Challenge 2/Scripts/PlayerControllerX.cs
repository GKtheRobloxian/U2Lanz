using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float InitialFireRate = 0.75f;
    float fireRate;

    private void Start()
    {
        fireRate = InitialFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && fireRate <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            fireRate = InitialFireRate;
        }
    }
}
