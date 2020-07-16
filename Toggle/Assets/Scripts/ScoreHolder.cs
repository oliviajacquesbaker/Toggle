using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    public static ScoreHolder Instance { get; private set; }
    private int finalScore;
    private int highScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.tag = "scoreH";
    }

    void Start()
    {
        scoreKeeper = (ScoreKeeper)ScoreKeeper.Instance;

    }

    public void UpdateScores()
    {
        finalScore = scoreKeeper.GetScore();
        if (finalScore > highScore)
        {
            highScore = finalScore;
        }
    }

    public int GetScore()
    {
        return finalScore;
    }

    public int GetHighSchore()
    {
        return highScore;
    }

    public void Reset()
    {
        scoreKeeper = (ScoreKeeper)ScoreKeeper.Instance;
    }
}
