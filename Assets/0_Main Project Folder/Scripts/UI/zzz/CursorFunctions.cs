using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorFunctions : MonoBehaviour
{
    [SerializeField] private int playerIndex = 0;

    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    [SerializeField] private Canvas canvas;
    
    

    private RectTransform rectTransform;

    public float cursorRadius = 3f;

    [SerializeField] private float UImoveSpeed = 10f;

    public GameObject primaryStamp;
    
    public GameObject secondaryStamp;
    
    private int lastHoveredPrimarySpell;

    private int lastHoveredSecondarySpell;

    private bool hoverPrimary = false;

    private bool hoverSecondary = false;

    private bool lockedPrimary = false;
    
    private bool lockedSecondary = false;

    public UIPlayerController UIcontroller;

    [SerializeField] private DisplayPlayerCell playerCell;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void MoveCursor(Vector2 pi)
    {
        //Debug.Log(pi);
        var currPos = rectTransform.anchoredPosition;
        var move = pi * Time.fixedDeltaTime * UImoveSpeed;
        if (transform.parent.GetComponent<RectTransform>().rect.Contains(currPos + move)) currPos += move;
        //currPos = new Vector2(Mathf.Clamp(currPos.x, cursorRadius, Screen.width - cursorRadius), Mathf.Clamp(currPos.y, cursorRadius, Screen.height - cursorRadius)); 
        rectTransform.anchoredPosition = currPos;
    }


    public void CheckForSpells()
    {
        
        #region Marcs RayCast System
        /*
        //Ray ray = Camera.main.ScreenPointToRay(rectTransform.position);
        var ray = new Ray(Camera.main.transform.position, transform.position);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.position -transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000))
        {
            var spellInfo = hit.collider.GetComponent<DisplaySpell>();
            //Debug.Log("I made it to hitting something, I hit " + hit.transform.name);
            if (hit.transform.CompareTag("Primary Spell"))
            {
                hoverPrimary = true;

                //  Commented out for debug purposes
                var indexOfHoveredSpell = hit.collider.GetComponent<SpellIndex>().spellIndex;
                Debug.Log(indexOfHoveredSpell);
                /*
                if (hit.transform.name != lastHoveredPrimarySpell.transform.name)
                {
                    lastHoveredPrimarySpell = hit.collider.gameObject;
                }(*,/)


                if (lastHoveredPrimarySpell != indexOfHoveredSpell)
                {
                    lastHoveredPrimarySpell = indexOfHoveredSpell;
                    playerCell.SetPrimarySpell(spellInfo.primarySpell);
                    
                    if (!lockedPrimary)
                    {
                        playerCell.UpdatePrimarySpell();
                    }
                }
            }
            else
            {
                hoverPrimary = false;
            }


            if (hit.transform.CompareTag("Secondary Spell"))
            {
                hoverSecondary = true;

                // commented out for debug purposes
                var indexOfHoveredSpell = hit.collider.GetComponent<SpellIndex>().spellIndex;

                /*
                if (hit.transform.name != lastHoveredSecondarySpell.transform.name)
                {
                    lastHoveredSecondarySpell = hit.collider.gameObject;
                }(*,/)


                if (lastHoveredSecondarySpell != indexOfHoveredSpell)
                {
                    lastHoveredSecondarySpell = indexOfHoveredSpell;
                    playerCell.SetSecondarySpell(spellInfo.secondarySpell);
                    
                    if (!lockedSecondary)
                    {
                        playerCell.UpdateSecondarySpell();
                    }
                    
                }
            }
            else
            {
                hoverSecondary = false;
            }
        }
        else
        {
            Debug.Log("I dont hit shit");
        } */
        #endregion
        
        #region My RayCast System
        
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = transform.position;
        
        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<SpellIndex>() != null)
            {
                if (result.gameObject.CompareTag("Primary Spell"))
                {
                    var spellInfo = result.gameObject.GetComponent<DisplaySpell>();
                
                    hoverPrimary = true;

                    //  Commented out for debug purposes
                    var indexOfHoveredSpell = result.gameObject.GetComponent<SpellIndex>().spellIndex;
                    //Debug.Log(indexOfHoveredSpell);
                
                    if (lastHoveredPrimarySpell != indexOfHoveredSpell)
                    {
                        lastHoveredPrimarySpell = indexOfHoveredSpell;
                        playerCell.SetPrimarySpell(spellInfo.primarySpell);
                    
                        if (!lockedPrimary)
                        {
                            playerCell.UpdatePrimarySpell();
                        }
                    }
                }
                else
                {
                    hoverPrimary = false;
                }
                
                if (result.gameObject.CompareTag("Secondary Spell"))
                {
                    var spellInfo = result.gameObject.GetComponent<DisplaySpell>();

                    hoverSecondary = true;
                
                    // commented out for debug purposes
                    var indexOfHoveredSpell = result.gameObject.GetComponent<SpellIndex>().spellIndex;
                    //Debug.Log(indexOfHoveredSpell);

                    if (lastHoveredSecondarySpell != indexOfHoveredSpell)
                    {
                        lastHoveredSecondarySpell = indexOfHoveredSpell;
                        playerCell.SetSecondarySpell(spellInfo.secondarySpell);
                    
                        if (!lockedSecondary)
                        {
                            playerCell.UpdateSecondarySpell();
                        }
                    
                    }
                }
                else
                {
                    hoverSecondary = false;
                }
            }
            
        }
        
        #endregion
        
    }


    public void Confirm()
    {
        if (hoverPrimary)
        {
            if (!lockedPrimary)
            {
                UIcontroller.LockPrimarySpell(lastHoveredPrimarySpell);
                
                lockedPrimary = true;
                primaryStamp.transform.parent = gameObject.transform.parent;
                primaryStamp.SetActive(true);
            }
            
        }

        if (hoverSecondary)
        {
            if (!lockedSecondary)
            {
                UIcontroller.LockSecondarySpell(lastHoveredSecondarySpell);

                lockedSecondary = true;
                secondaryStamp.transform.parent = gameObject.transform.parent;
                secondaryStamp.SetActive(true);
            }
            
        }
    }

    public void CancelSelection()
    {
        lockedPrimary = false;
        lockedSecondary = false;

        UIcontroller.lockedPrimarySpellIndex = 0;
        UIcontroller.lockedSecondarySpellIndex = 0;
        
        primaryStamp.SetActive(false);
        secondaryStamp.SetActive(false);
        
        primaryStamp.transform.parent = gameObject.transform;
        secondaryStamp.transform.parent = gameObject.transform;
        
        primaryStamp.transform.localPosition = Vector3.zero;
        secondaryStamp.transform.localPosition = Vector3.zero;
        
        CustomUIeventManager.current.PlayerNotReady();
        CustomUIeventManager.current.NotAllPlayersReady();
    }
}