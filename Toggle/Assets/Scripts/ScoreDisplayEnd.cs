using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplayEnd : MonoBehaviour
{
    private int score;
    private int hiScore;
    private TextMeshProUGUI scoreText;
    private ScoreHolder scoreHolder;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreHolder = GameObject.FindGameObjectWithTag("scoreH").GetComponent<ScoreHolder>();
        SetScoreText();
    }

    void SetScoreText()
    {
        score = scoreHolder.GetScore();
        hiScore = scoreHolder.GetHighSchore();
        scoreText.text = ( score.ToString() + "\n" + hiScore.ToString());
    }

}
