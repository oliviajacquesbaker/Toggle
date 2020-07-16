using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    private int score;
    private TextMeshProUGUI scoreText;


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
        scoreText = GetComponent<TextMeshProUGUI>();
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

    public int GetScore()
    {
        return score;
    }

}
