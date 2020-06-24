using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfig> playerConfigs;
    public bool allPlayersReady = false;

    [SerializeField] private int maxPlayers = 2;

    public delegate void PlayersReady();

    public PlayersReady playersReady;


    public delegate void PlayersUnready();

    public PlayersUnready playersUnready;


    #region Singleton

    public static PlayerConfigManager self { get; private set; }

    private void Awake()
    {
        if (self != null)
        {
            Debug.Log("SINGLETON - Trying to create another instance. Destroying this gameobject!");
            Destroy(gameObject);
        }
        else
        {
            self = this;
            DontDestroyOnLoad(self);
            playerConfigs = new List<PlayerConfig>();
        }
    }

    #endregion

    public void SetPlayerColor(int pIndex, Material color)
    {
        playerConfigs[pIndex].pMaterial = color;
    }

    public void SetPlayerScale(int pIndex, float scale)
    {
        playerConfigs[pIndex].pScale *= scale;
    }

    public void ReadyPlayer(int pIndex)
    {
        playerConfigs[pIndex].isReady = true;

        if (playerConfigs.Count == maxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            allPlayersReady = true;

            if (playersReady != null) playersReady.Invoke();
            //SceneManager.LoadScene("Multiplayer Test");
        }
    }

    public void UnreadyPlayer(int pIndex)
    {
        playerConfigs[pIndex].isReady = false;

        if (allPlayersReady)
        {
            allPlayersReady = false;
            if (playersUnready != null) playersUnready.Invoke();
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player" + pi.playerIndex + "joined");
        if (!playerConfigs.Any(p => p.pIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfig(pi));
        }
    }
}