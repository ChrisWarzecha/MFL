using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    // This Script takes care of calling functions from other scripts concerning the player as well as getting input 
    
    #region Allgemeine Variablen
    private PlayerInput playerInput;

    [SerializeField] private int PlayerIndex;

    //saves input of left stick
    private Vector2 i_movement;
    
    public int lockedPrimarySpellIndex; //might still need this

    public int lockedSecondarySpellIndex; //might still need this

    public Spell PrimarySpell;
    
    public Spell SecondarySpell;
    
    //Hard reference to PlayerActions script (separate to keep everything working)
    [SerializeField] private PlayerActions playerActions;
    #endregion

    
    
    #region In-Game Scene related Variablen
    //saves input of right stick
    private Vector2 i_rotateDirection;

    public Vector2 Spells;
    
    public bool inPossession = false;
    #endregion
    


    #region Spell Selection Scene related Variablen
    private bool playerReady = false;
    private bool sentEvent = false;

    private bool allReady = false;
    #endregion
    
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var allPlayerActions = FindObjectsOfType<PlayerActions>();
        var index = playerInput.playerIndex;
        playerActions = allPlayerActions.FirstOrDefault(c => c.GetPlayerIndex() == index);
        
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        playerActions.controller = this;
        
        DontDestroyOnLoad(gameObject);

        //Spell Selection Event Subscriptions
        CustomEventManager.current.OnAllPlayersReady += OnAllPlayersReady;
        CustomEventManager.current.OnNotAllPlayersReady += OnNotAllPlayersReady;
        CustomEventManager.current.OnAboutToLoadNewScene += OnAboutToLoadNewScene;
        
        //In-Game Event Subscriptions
        CustomEventManager.current.OnRelicPickUp += OnRelicPickUp;
        CustomEventManager.current.OnResetRound += OnResetRound;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Spell Select Test")
        {
            if (i_movement != Vector2.zero) playerActions.CheckForSpells();

            CheckForReady();
        }
    }

    private void FixedUpdate()
    {
        //All Physics stufff belongs in FixedUpdate
        if (SceneManager.GetActiveScene().name == "Spell Select Test")
        {
            if (playerActions != null)
            {
                playerActions.MoveCursor(i_movement);
            }
        }

        if (SceneManager.GetActiveScene().name == "Multiplayer Test")
        {
            playerActions.Move(i_movement);
            playerActions.Rotate(i_rotateDirection);
        }
    }
    
    
    
    #region Spell Selection Scene related methods
    private void OnMoveCursor(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }
    
    private void OnConfirm()
    {
        if (!allReady)
        {
            playerActions.Confirm();
        }
        if (allReady)
        {
            if (playerInput.playerIndex == 0)
            {
                CustomGameManager.current.StartGame();
            }
        }
    }
    
    private void OnCancelSelection()
    {
        playerActions.CancelSelection();
        playerReady = false;
        sentEvent = false;
        Debug.Log("Player " + (playerInput.playerIndex + 1) + " is not ready anymore!");
    }
    
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
                CustomEventManager.current.PlayerIsReady();
                sentEvent = true;
            }
        }
    }
    #endregion

    
    
    #region In-Game Scene related methods
    //Check for and safe Input
    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }

    private void OnJump()
    {
        playerActions.Jump();
    }

    private void OnLookAround(InputValue value)
    {
        
        i_rotateDirection = value.Get<Vector2>();
        
    }
    
    private void OnThrowRelic()
    {
        if (inPossession)
        {
            playerActions.ThrowRelic();
            StartCoroutine(delayPossessionLoss(0.02f));
        }
    }
    
   
    
    private void OnDropRelic()
    {
        if (inPossession)
        {
            playerActions.DropRelic();
            StartCoroutine(delayPossessionLoss(0.02f));
        }
    }
    
    private void OnCastPrimarySpell()
    {
        if (!inPossession)
        {
            playerActions.CastPrimarySpell((int) Spells.x - 1);
        }
    }
    
    private void OnCastSecondarySpell()
    {
        if (!inPossession)
        {
            playerActions.CastSecondarySpell((int) Spells.y - 1);
        }
    }
    
    private void OnDash()
    {
        if (inPossession)
        {
            playerActions.Dash(i_movement);
        }
    }
    
    public IEnumerator delayPossessionLoss(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        inPossession = false;
    }
    #endregion



    #region Spell Selection Scene related Event methods
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
            playerInput.SwitchCurrentActionMap("Player");
            
            //erneut alle PlayerAction Scripts holen und zuweisen
            var allPlayerActions = FindObjectsOfType<PlayerActions>();
            var index = playerInput.playerIndex;
            playerActions = allPlayerActions.FirstOrDefault(c => c.GetPlayerIndex() == index);
            playerActions.controller = this;
            
            //Get Spells
            Spells = CustomSpellManager.current.GetSpells(playerInput.playerIndex); // = new Vector2 (1/3) Bei den beiden oberen Spells
            
            //assign scriptable object spells to slots
            PrimarySpell = CustomSpellManager.current.allSpells[lockedPrimarySpellIndex - 1];
            SecondarySpell = CustomSpellManager.current.allSpells[lockedSecondarySpellIndex - 1];
        }
        if (s.name == "Spell Select Test")
        {
            playerInput.SwitchCurrentActionMap("UI Navigation");
        }
        
    }
    #endregion
    
    
    
    #region In-Game Scene related Event methods
    private void OnRelicPickUp(int pi)
    {
        if (pi != playerActions.GetPlayerIndex())
        {
            return;
        }
        else
        {
            inPossession = true;
        }
    }

    private void OnResetRound()
    {
        playerActions.ResetPlayerPosition();
    }
    #endregion

    
    
}