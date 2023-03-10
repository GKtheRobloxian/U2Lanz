using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimalForward : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > 30)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 40)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -40)
        {
            Destroy(gameObject);
        }
    }
}
