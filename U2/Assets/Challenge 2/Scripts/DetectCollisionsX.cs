using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.y < -4)
        {
            Debug.Log("Game Over!");
        }
    }
}
