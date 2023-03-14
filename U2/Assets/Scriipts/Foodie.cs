using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foodie : MonoBehaviour
{
    public static Foodie instance { get; private set; }

    public Slider slider;
    AnimalForward moo;
    // Start is called before the first frame update
    void Start()
    {
        moo = GetComponent<AnimalForward>();
        slider.maxValue = gameObject.AnimalForward.Hunger;
        slider.value = 0;
        slider.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(float value)
    {
        slider.fillRect.gameObject.SetActive(true);
        slider.value = value;
    }
}
