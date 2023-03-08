using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDashBar : MonoBehaviour
{
    public static UiDashBar instance { get; private set; }

    public Image mask;

    private void Awake()
    {
        instance = this;
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
}
