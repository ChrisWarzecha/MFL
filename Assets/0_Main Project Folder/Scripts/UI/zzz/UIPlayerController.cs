using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIPlayerController : MonoBehaviour
{
    private PlayerInput playerInput;

    private Vector2 i_movement;

    public int lockedPrimarySpellIndex;

    public int lockedSecondarySpellIndex;

    private bool playerReady = false;
    private bool sentEvent = false;

    private bool allReady = false;
    

    //[SerializeField] 
    private CursorFunctions cursorFunctions;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var allCursorFunctions = FindObjectsOfType<CursorFunctions>();
        var index = playerInput.playerIndex;
        cursorFunctions = allCursorFunctions.FirstOrDefault(c => c.GetPlayerIndex() == index);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        cursorFunctions.UIcontroller = this;

        CustomUIeventManager.current.OnAllPlayersReady += OnAllPlayersReady;
        CustomUIeventManager.current.OnNotAllPlayersReady += OnNotAllPlayersReady;
        CustomUIeventManager.current.OnAboutToLoadNewScene += OnAboutToLoadNewScene;
        
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Spell Select Test")
        {
            if (i_movement != Vector2.zero) cursorFunctions.CheckForSpells();

            CheckForReady();
            Debug.Log(playerInput.actions.actionMaps[1]);
        }
        

        /*
        if (playerReady) //& playerReady = false
        {
            playerReady = true;
            Debug.Log("Player " + (playerInput.playerIndex + 1) + " is ready!");
        }*/
    }


    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Spell Select Test")
        {
            if (cursorFunctions != null)
            {
                cursorFunctions.MoveCursor(i_movement);
            }
            //cursorFunctions.MoveCursor(i_movement);
        }
        
    }

    private void OnMoveCursor(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }

    private void OnConfirm()
    {
        if (!allReady)
        {
            cursorFunctions.Confirm();
        }
        if (allReady)
        {
            Debug.Log("I get input");

            Debug.Log(playerInput.playerIndex);
            if (playerInput.playerIndex == 0)
            {
                CustomUIgameManager.current.StartGame();
            }
        }
    }

    private void OnCancelSelection()
    {
        cursorFunctions.CancelSelection();
        playerReady = false;
        sentEvent = false;
        Debug.Log("Player " + (playerInput.playerIndex + 1) + " is not ready anymore!");
    }

    private void OnStartGame()
    {
        
    } //nachprüfen, wie ich aktuell das spiel starte und checken, ob diese funktion irrelevant ist

    public void LockPrimarySpell(int index)
    {
        lockedPrimarySpellIndex = index;
    }

    public void LockSecondarySpell(int index)
    {
        lockedSecondarySpellIndex = index;
    }

    private void CheckForReady()
    {
        if (this.lockedPrimarySpellIndex != 0 && this.lockedSecondarySpellIndex != 0)
        {
            playerReady = true;
            if (!sentEvent)
            {
                CustomUIeventManager.current.PlayerIsReady();
                sentEvent = true;
            }
        }
    }

    private void OnAllPlayersReady()
    {
        allReady = true;
    }
    
    private void OnNotAllPlayersReady()
    {
        allReady = false;
    }

    private void OnAboutToLoadNewScene()
    {
        CustomSpellManager.current.SetSpells(playerInput.playerIndex, lockedPrimarySpellIndex, lockedSecondarySpellIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        var s = scene;
        var m = loadMode;
        if (s.name == "Multiplayer Test")
        {
            Debug.Log("I realize a specific scene is loaded");
            playerInput.SwitchCurrentActionMap("Player");
        }
        if (s.name == "Spell Select Test")
        {
            playerInput.SwitchCurrentActionMap("UI Navigation");
        }
        
    }
    
    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
        Debug.Log("I have switched my Map and now react to Player Functions");
    }
}



