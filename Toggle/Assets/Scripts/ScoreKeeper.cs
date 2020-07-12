using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    private int score;
    private Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        SetScoreText();
    }

    public void CapturePoint()
    {
        score += 3;
        SetScoreText();
    }

    public void BeatEnemy()
    {
        score += 5;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
