using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private ScoreHolder scoreHolder;

    void Start()
    {
        scoreHolder = GameObject.FindGameObjectWithTag("scoreH").GetComponent<ScoreHolder>();

    }

    public void ResetPlayMode()
    {
        scoreHolder.Reset();
    }
}
