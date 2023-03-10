using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDashBar : MonoBehaviour
{
    public static UiDashBar instance { get; private set; }

    public Image mask;
    public TMP_Text TMP;
    int score;
    DetectCollisions collisions;

    private void Awake()
    {
        instance = this;
        collisions = GetComponent<DetectCollisions>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        mask.transform.localScale = (new Vector3 (1, value, 1));
    }

    public void Scorey()
    {
        score += 1;
        TMP.text = "Score: " + score;
    }
}
