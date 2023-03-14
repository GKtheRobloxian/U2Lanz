using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    Canvas Ui;
    UiDashBar UI;
    TMP_Text TMP;

    // Start is called before the first frame update
    void Awake()
    {
        Ui = FindObjectOfType<Canvas>();
        UI = Ui.GetComponent<UiDashBar>();
    }

    // Update is called once per frame
    void Update()
    {
        TMP = FindObjectOfType<TMP_Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            return;
        }
    }
}
