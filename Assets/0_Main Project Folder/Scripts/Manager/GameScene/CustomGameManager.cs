using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomGameManager : MonoBehaviour
{
    public static CustomGameManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }
    
    
    
    #region Spell Selection related Variablen
    [SerializeField] private int maxPlayers = 4;
    [SerializeField] private int playersReady = 0;
    private bool allPlayersReady = false;
    #endregion
    
    
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //Spell Selection Event Subscriptions
        CustomEventManager.current.OnPlayerIsReady += PlayerIsReady;
        CustomEventManager.current.OnPlayerNotReady += PlayerNotReady;
        CustomEventManager.current.OnNotAllPlayersReady += NotAllPlayersReady;
        
        //In-Game Event Subscriptions
        CustomEventManager.current.OnGameEnd += EndGame;
        CustomEventManager.current.OnGoalScored += ResetRound;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Spell Select Test")
        {
            CheckAllPlayersReady();
            if (allPlayersReady)
            {
                CustomEventManager.current.AllPlayersReady();
                //Debug.Log("I raised event");
            }
        }
    }



    #region Spell Selection Methoden
    //Normale Methoden
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
        //Debug.Log("I started the game");
        //Hier beginnt das Spiel, ob ich jetzt die Scene neu lade oder hier irgendwas an/ausschalte ist egal
        
        
        //Save Spells to Spell Manager
        CustomEventManager.current.AboutToLoadNewScene();
        
        
        SceneManager.LoadScene(1);
    }
    
    //Event Methoden
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
    #endregion



    #region In-Game Methoden
    //Normale Methoden
    private void EndGame(int indexTeamWon)
    {
        Debug.Log("I ended the game, Team " + indexTeamWon + " has won!");
    }

    private void ResetRound(int indexTeamGotScored)
    {
        Debug.Log("Round has been reset!");
        CustomEventManager.current.ResetRound();
    }
    #endregion
    
    
    
}
