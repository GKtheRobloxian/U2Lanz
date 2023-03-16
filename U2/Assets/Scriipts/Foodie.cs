using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foodie : MonoBehaviour
{
    public static Foodie instance { get; private set; }

    public GameObject animal;
    public Slider slider;
    public Image sliderFill;
    public int maxValue;
    float sliderPercentage;
    AnimalForward Animal;
    
    void Awake()
    {
        Animal = animal.GetComponent<AnimalForward>();
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxValue;
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
