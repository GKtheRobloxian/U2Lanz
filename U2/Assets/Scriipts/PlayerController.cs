using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float dashTimer = 5.0f;
    public float xRange = 16f;
    public float initialFireRate = 0.5f;
    public GameObject projectile;
    float fireRate;
    float usedTimer;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = initialFireRate;
        usedTimer = dashTimer;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * -1);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            usedTimer = dashTimer;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            usedTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)&&usedTimer < 0)
        {
            transform.position = new Vector3 (-15, 0, 0);
            usedTimer = dashTimer;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            usedTimer = dashTimer;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            usedTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && usedTimer < 0)
        {
            transform.position = new Vector3(15, 0, 0);
            usedTimer = dashTimer;
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange+1, 0, 0);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange-1, 0, 0);
        }
        if(fireRate < 0 && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            fireRate = initialFireRate;
        }
    }
}
