using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int playerIndex;


    [SerializeField] private TextMeshProUGUI titeText;

    [SerializeField] private GameObject readyPanel;

    [SerializeField] private GameObject menuPanel;

    [SerializeField] private Button readyButton;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    private void Start()
    {
        PlayerConfigManager.self.playersReady += GameReady;
        PlayerConfigManager.self.playersUnready += GameUnready;
    }

    private void GameReady()
    {
    }

    private void GameUnready()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > ignoreInputTime) inputEnabled = true;
    }

    public void SetPlayerIndex(int pi)
    {
        playerIndex = pi;
        titeText.SetText("Player" + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    public void SetPrimarySpell(Material color)
    {
        if (!inputEnabled) return;

        PlayerConfigManager.self.SetPlayerColor(playerIndex, color);
        //readyPanel.SetActive(true);
        //readyButton.Select();
        //menuPanel.SetActive(false);
    }

    public void SetSecondarySpell(float scale)
    {
        if (!inputEnabled) return;

        PlayerConfigManager.self.SetPlayerScale(playerIndex, scale);
        //readyPanel
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) return;

        PlayerConfigManager.self.ReadyPlayer(playerIndex);
        readyButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerConfigManager.self.playersReady -= GameReady;
        PlayerConfigManager.self.playersUnready -= GameUnready;
    }
}