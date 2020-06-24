using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomEventManager : MonoBehaviour
{
    public static CustomEventManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    //Spell Selection Events
    public event Action OnPlayerIsReady;
    public event Action OnPlayerNotReady;
    public event Action OnAllPlayersReady;
    public event Action OnNotAllPlayersReady;
    public event Action OnAboutToLoadNewScene;
    public event Action<Scene, LoadSceneMode> OnSceneLoaded;
    
    //In-Game Events
    public event Action<int> OnRelicPickUp;
    public event Action OnRelicThrown;
    public event Action OnRelicDropped;
    
    public event Action<int> OnGoalScored;
    public event Action<int> OnGameEnd;
    public event Action OnResetRound;
    
    public event Action<int> OnPrimarySpellCast; //unnötig, behalte sie als gedankenanstoß, für den Fall dass was schief geht
    
    
    
    #region Spell Selection Events
    public void PlayerIsReady()
    {
        if (OnPlayerIsReady != null)
        {
            OnPlayerIsReady();
        }
    }
    
    public void PlayerNotReady()
    {
        if (OnPlayerNotReady != null)
        {
            OnPlayerNotReady();
        }
    }
    
    public void AllPlayersReady()
    {
        if (OnAllPlayersReady != null)
        {
            OnAllPlayersReady();
        }
    }
    
    public void NotAllPlayersReady()
    {
        if (OnNotAllPlayersReady != null)
        {
            OnNotAllPlayersReady();
        }
    }
    
    public void AboutToLoadNewScene()
    {
        if (OnAboutToLoadNewScene != null)
        {
            OnAboutToLoadNewScene();
        }
    }
    #endregion
    
    
    
    #region In-Game Events
    public void RelicPickedUp(int pi)
    {
        if (OnRelicPickUp != null)
        {
            OnRelicPickUp(pi);
        }
    }

    public void RelicThrown()
    {
        if (OnRelicThrown != null)
        {
            OnRelicThrown();
        }
    }
    
    public void RelicDropped()
    {
        if (OnRelicDropped != null)
        {
            OnRelicDropped();
        }
    }
    
    public void GoalScored(int teamIndex)
    {
        if (OnGoalScored != null)
        {
            OnGoalScored(teamIndex);
        }
    }

    public void GameEnd(int indexTeamWon)
    {
        if (OnGameEnd != null)
        {
            OnGameEnd(indexTeamWon);
        }
    }
    
    public void ResetRound()
    {
        if (OnResetRound != null)
        {
            OnResetRound();
        }
    }

    public void PrimarySpellCast(int pIndex)
    {
        if (OnPrimarySpellCast != null)
        {
            OnPrimarySpellCast(pIndex);
        }
    }
    #endregion
    
}
