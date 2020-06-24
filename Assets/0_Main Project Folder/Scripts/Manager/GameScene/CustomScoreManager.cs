using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomScoreManager : MonoBehaviour
{
    public static CustomScoreManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }
    
    [SerializeField] private int scoreTone = 0;

    [SerializeField] private int scoreTtwo = 0;

    void Start()
    {
        CustomEventManager.current.OnGoalScored += OnGoalScored;
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
        CustomEventManager.current.GameEnd(indexTeamWon);
    }

    private void LoadNewRound()
    {
        CustomEventManager.current.ResetRound();
    }

    public Vector2 GetScoreCount()
    {
        return new Vector2(scoreTone, scoreTtwo);
    }

}


