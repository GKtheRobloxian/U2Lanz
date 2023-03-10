using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float dashTimer = 5.0f;
    public float xRange = 16f;
    public float zRange = 10f;
    public float initialFireRate = 0.5f;
    public GameObject projectile;
    float fireRate;
    float usedTimer;
    float addition;
    float additionz;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = initialFireRate;
        usedTimer = dashTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (usedTimer <= 0)
        {
            usedTimer = 0;
        }
        if ((transform.position.x < 0 && (Input.GetKey(KeyCode.RightArrow)))||(transform.position.x > 0 && (Input.GetKey(KeyCode.LeftArrow))))
        {
            addition = 15.0f + Mathf.Abs(transform.position.x);
        }
        else if ((transform.position.x > 0&&(Input.GetKey(KeyCode.RightArrow)))||(transform.position.x < 0 && Input.GetKey(KeyCode.LeftArrow)))
        {
            addition = 15-Mathf.Abs(transform.position.x);
        }
        else
        {
            addition = 15;
        }
        if (transform.position.z > 0 && (Input.GetKey(KeyCode.UpArrow)))
        {
            additionz = 15.5f - transform.position.z;
        }
        if (transform.position.z > 0 && Input.GetKey(KeyCode.DownArrow))
        {
            additionz = 2.25f + transform.position.z;
        }
        if (transform.position.z < 0 && Input.GetKey(KeyCode.DownArrow))
        {
            additionz = 2.25f - Mathf.Abs(transform.position.z);
        }
        if (transform.position.z < 0 && (Input.GetKey(KeyCode.UpArrow)))
        {
            additionz = 15.5f + Mathf.Abs(transform.position.z);
        }
        fireRate -= Time.deltaTime;
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * -1);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            usedTimer = dashTimer;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            usedTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)&&usedTimer <= 0)
        {
            transform.position = new Vector3(-15, 0, transform.position.z);
            usedTimer = dashTimer;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && usedTimer > 0)
        {
            transform.position = new Vector3(transform.position.x - ((dashTimer - usedTimer) / dashTimer * addition), 0, transform.position.z);
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
        if (Input.GetKeyUp(KeyCode.RightArrow) && usedTimer <= 0)
        {
            transform.position = new Vector3(15, 0, transform.position.z);
            usedTimer = dashTimer;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && usedTimer > 0)
        {
            transform.position = new Vector3(transform.position.x + ((dashTimer - usedTimer) / dashTimer * addition), 0, transform.position.z);
            usedTimer = dashTimer;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            usedTimer = dashTimer;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            usedTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && usedTimer <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 15.5f);
            usedTimer = dashTimer;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && usedTimer > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z + ((dashTimer - usedTimer)/dashTimer*addition));
            usedTimer = dashTimer;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            usedTimer = dashTimer;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            usedTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && usedTimer <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, -2.25f);
            usedTimer = dashTimer;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && usedTimer > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z - ((dashTimer - usedTimer)/dashTimer * addition));
            usedTimer = dashTimer;
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, 0, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, 0, transform.position.z);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, 0, zRange);
        }
        if (transform.position.z < -2.25)
        {
            transform.position = new Vector3(transform.position.x, 0, -2.25f);
        }    
        if(fireRate < 0 && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            fireRate = initialFireRate;
        }
        UiDashBar.instance.SetValue((dashTimer - usedTimer) / dashTimer);
    }
    private void OnTriggerEnter(Collider other)
    {
        AnimalForward controller = other.GetComponent<AnimalForward>();
        if (controller != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Crash!");
        }
    }
}
