using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFLScoreManager : MonoBehaviour
{
    public static MFLScoreManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public int scoreTone = 0;

    public int scoreTtwo = 0;

    void Start()
    {
        MFLEventManager.current.OnGoalScored += OnGoalScored;
    }

    private void OnGoalScored(int teamIndex)
    {
        UpdateScore(teamIndex);
        
        if (scoreTone == 3 || scoreTtwo == 3)
        {
            GameEnd(CheckWinner(scoreTone, scoreTtwo));
        }
        else
        {
            LoadNewRound();
        }
    }

    private void UpdateScore(int teamIndex)
    {
        if (teamIndex == 1)
        {
            scoreTtwo += 1;
        }

        if (teamIndex == 2)
        {
            scoreTone += 1;
        }
    }

    private int CheckWinner(int scoreTone, int scoreTtwo)
    {
        if (scoreTone > scoreTtwo)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private void GameEnd(int indexTeamWon)
    {
        MFLEventManager.current.GameEnd(indexTeamWon);
    }

    private void LoadNewRound()
    {
        MFLEventManager.current.ResetRound();
    }

    public Vector2 GetScoreCount()
    {
        return new Vector2(scoreTone, scoreTtwo);
    }

    private void OnDestroy()
    {
        MFLEventManager.current.OnGoalScored -= OnGoalScored;
    }
}


