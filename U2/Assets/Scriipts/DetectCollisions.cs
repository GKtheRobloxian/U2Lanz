using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    UiDashBar UI;
    TMP_Text TMP;
    int score;

    // Start is called before the first frame update
    void Awake()
    {
        UI = GetComponent<UiDashBar>();
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
        else
        {
            UI.Scorey();
            TMP = FindObjectOfType<TMP_Text>();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
