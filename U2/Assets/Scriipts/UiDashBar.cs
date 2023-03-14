using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDashBar : MonoBehaviour
{
    public static UiDashBar instance { get; private set; }

    public GameObject projectile;
    public GameObject Gameover;
    public TMP_Text Life;
    public Image mask;
    public TMP_Text Score;
    int score;
    DetectCollisions collisions;

    private void Awake()
    {
        instance = this;
        collisions = projectile.GetComponent<DetectCollisions>();
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

    public void GameOver()
    {
        Gameover.SetActive(true);
    }

    public void LifeText(int integer)
    {
        Life.text = "Lives: " + integer;
    }

    public void Scorey(int integer)
    {
        score += integer;
        Score.text = "Score: " + score;
    }
}
