using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomUIgameManager : MonoBehaviour
{
    public static CustomUIgameManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    [SerializeField] private int maxPlayers = 4;
    [SerializeField] private int playersReady = 0;
    private bool allPlayersReady = false;

    private void Start()
    {
        CustomUIeventManager.current.OnPlayerIsReady += PlayerIsReady;
        CustomUIeventManager.current.OnPlayerNotReady += PlayerNotReady;
        CustomUIeventManager.current.OnNotAllPlayersReady += NotAllPlayersReady;

    }

    private void Update()
    {
        CheckAllPlayersReady();
        if (allPlayersReady)
        {
            CustomUIeventManager.current.AllPlayersReady();
        }
        Debug.Log(allPlayersReady);
    }

    private void PlayerIsReady()
    {
        playersReady += 1;
    }
    
    private void PlayerNotReady()
    {
        playersReady -= 1;
    }

    private void NotAllPlayersReady()
    {
        allPlayersReady = false;
    }



    private void CheckAllPlayersReady()
    {
        if (playersReady == maxPlayers)
        {
            allPlayersReady = true;
        }
        else
        {
            allPlayersReady = false;
        }
    }

    public void StartGame()
    {
        Debug.Log("I started the game");
        //Hier beginnt das Spiel, ob ich jetzt die Scene neu lade oder hier irgendwas an/ausschalte ist egal
        
        
        //Disable UI Controls to prevent Exceptions
        CustomUIeventManager.current.AboutToLoadNewScene();
        
        
        //Ich muss mir nochmal anschauen, wie man die nächste Scene lädt
        SceneManager.LoadScene(1);
    } 
    
    
}
