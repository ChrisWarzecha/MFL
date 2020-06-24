using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAllReadyBanner : MonoBehaviour
{
    private Image img;
    
    
    
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    void Start()
    {
        CustomEventManager.current.OnAllPlayersReady += ActivateImage;
        CustomEventManager.current.OnNotAllPlayersReady += DeactivateImage;

    }

    private void ActivateImage()
    {
        img.enabled = true;
    }
    
    private void DeactivateImage()
    {
        img.enabled = false;
    }
    
}
