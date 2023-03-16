using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimalForward : MonoBehaviour
{
    public float speed = 10.0f;
    public int maxHunger;
    public int destroyScore;
    int Hunger;
    GameObject Ui;
    UiDashBar UI;
    TMP_Text TMP;
    Slider slide;
    Foodie food;
    // Start is called before the first frame update
    void Start()
    {
        food = GetComponent<Foodie>();
        Ui = GameObject.Find("/UltraInstinct");
        UI = Ui.GetComponent<UiDashBar>();
        food.maxValue = maxHunger;
        Hunger = maxHunger;
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
    private void OnTriggerEnter(Collider other)
    {
        DetectCollisions collision = other.GetComponent<DetectCollisions>();
        if (collision != null)
        {
            UI.Scorey(1);
            Destroy(other.gameObject);
            Hunger -= 1;
            food.SetValue(maxHunger - Hunger);
            if (Hunger == 0)
            {
                UI.Scorey(destroyScore);
                Destroy(gameObject);
            }
        }
    }
}
