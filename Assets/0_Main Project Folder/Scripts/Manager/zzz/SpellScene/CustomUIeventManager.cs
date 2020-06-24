using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomUIeventManager : MonoBehaviour
{
    public static CustomUIeventManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    public event Action OnPlayerIsReady;
    public event Action OnPlayerNotReady;
    public event Action OnAllPlayersReady;
    public event Action OnNotAllPlayersReady;
    public event Action OnAboutToLoadNewScene;
    public event Action<Scene, LoadSceneMode> OnSceneLoaded;


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
}
