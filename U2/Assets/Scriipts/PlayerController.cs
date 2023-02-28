using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime*speed);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
            Debug.Log("Dash!");
        }

    }
}