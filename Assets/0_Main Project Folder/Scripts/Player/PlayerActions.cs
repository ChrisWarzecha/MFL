using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(CapsuleCollider))]
public class PlayerActions : MonoBehaviour
{
    #region Allgemeine Variablen
    [SerializeField] private int playerIndex = 0;
    
    [SerializeField] private int teamIndex;
    #endregion



    #region Spell Selection Scene related Variables
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

    public PlayerController controller;

    [SerializeField] private DisplayPlayerCell playerCell;
    #endregion
    
    
    
    #region In-Game Scene related Variables
    [Header("Camera Variables")]
    //hard reference to camera
    public CinemachineVirtualCamera vCam;

    //only for future purposes
    public bool xAxisRotation = true;

    //rotation speed of player
    public float horizontalSensitivity = 10.0f;

    public float verticalSensitivity = 10.0f;

    //values to limit cam movement along y axis
    public float minCamHeight = -1.0f;
    public float maxCamHeight = 7.5f;
    public Transform preRotator;

    [Header("Movement Variables")]
    //only for protoyping and showcae in coaching
    public bool translationMovement = true;

    //movement speed of player
    public float moveSpeed = 10f;

    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private float raycastExtension = 0.2f;

    [SerializeField] private float dashForce = 3000.0f;
    [SerializeField] private float dashDuration = 2.0f;
    [SerializeField] private float dashCooldown = 14.0f;
    private bool dashOnCD = false;


    private bool primOnCD = false;
    private bool secOnCD = false;

    [SerializeField] private Transform spawnPoint;

    public Rigidbody rBody;

    public Transform RelicTargetPosition;
    #endregion


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        if(canvas != null) m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position,Vector3.down * raycastExtension, Color.cyan);
    }

    
    
    #region Allgemeine Methoden
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    #endregion



    #region Spell Selection Scene related Methoden
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
                controller.LockPrimarySpell(lastHoveredPrimarySpell);
                lockedPrimary = true;
                primaryStamp.transform.parent = gameObject.transform.parent;
                primaryStamp.SetActive(true);
            }
            
        }

        if (hoverSecondary)
        {
            if (!lockedSecondary)
            {
                controller.LockSecondarySpell(lastHoveredSecondarySpell);
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

        controller.lockedPrimarySpellIndex = 0;
        controller.lockedSecondarySpellIndex = 0;
        
        primaryStamp.SetActive(false);
        secondaryStamp.SetActive(false);
        
        primaryStamp.transform.parent = gameObject.transform;
        secondaryStamp.transform.parent = gameObject.transform;
        
        primaryStamp.transform.localPosition = Vector3.zero;
        secondaryStamp.transform.localPosition = Vector3.zero;

        if (controller.playerReady)
        {
            MFLEventManager.current.PlayerNotReady();
            MFLEventManager.current.NotAllPlayersReady();
        }
    }
    #endregion
    
    
    
    #region In-Game Scene related Methoden
    public void Move(Vector2 i_movement)
    {
        if (translationMovement)
        {
            // Old code with stinky translations.
            var playerMovement = new Vector3(i_movement.x, 0, i_movement.y) * moveSpeed * Time.fixedDeltaTime;
            transform.Translate(playerMovement);
        }
        else
        {
            /*
            Vector3 inputVector = transform.worldToLocalMatrix.MultiplyVector(new Vector3(i_movement.x,0, i_movement.y));
            //Debug.DrawRay(transform.position, localForward, Color.green);
            inputVector.y = rBody.velocity.y;
            //rBody.velocity = inputVector * moveSpeed * Time.fixedDeltaTime; */

            //rBody.velocity = new Vector3(i_movement.x,rBody.velocity.y, i_movement.y) * moveSpeed * Time.fixedDeltaTime; 

            //rBody.MovePosition(new Vector3(i_movement.x,0, i_movement.y) * moveSpeed * Time.fixedDeltaTime);

            var moveTo = transform.forward * i_movement.y + transform.right * i_movement.x;

            if (moveTo.magnitude > 0f)
            {
                rBody.MovePosition(moveTo * Time.fixedDeltaTime * moveSpeed + rBody.transform.position);
            }
        }
    }

    public void Rotate(Vector2 i_rotateDirection)
    {
        //transform.Rotate(Vector3.up, i_rotateDirection.x * horizontalSensitivity * Time.fixedDeltaTime);
        //getRotation(i_rotateDirection);
        rBody.MoveRotation(getTargetRotation(i_rotateDirection));

        if (xAxisRotation)
        {
            var transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
            var yBody = transposer.m_FollowOffset.y - i_rotateDirection.y * verticalSensitivity * Time.fixedDeltaTime;
            yBody = Mathf.Clamp(yBody, minCamHeight, maxCamHeight);
            transposer.m_FollowOffset.y = yBody;
        }
    }

    public Quaternion getTargetRotation(Vector2 i_rotateDirection)
    {
        preRotator.transform.Rotate(Vector3.up, i_rotateDirection.x * horizontalSensitivity * Time.fixedDeltaTime);

        var targetRotation = preRotator.transform.rotation;

        preRotator.localRotation = Quaternion.Euler(0, 0, 0);

        return targetRotation;
    }
    
    public void Jump()
    {
        if (CheckForGrounded())
        {
            rBody.velocity = Vector3.up * jumpForce;
            //rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            return;
        }
    }
    
    public void ThrowRelic()
    {
        //Debug.Log("I threw the relic");
        MFLEventManager.current.RelicThrown();
    }
    
    
    public void DropRelic()
    {
        //Debug.Log("I dropped the relic");
        MFLEventManager.current.RelicDropped();
    }
    
    public void Dash(Vector2 inputVector)
    {
        /*
        Debug.Log("I dashed in direction of " + inputVector);
        rBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * dashForce, ForceMode.Impulse);
        //start cooldown */

        if (!dashOnCD)
        {
            dashOnCD = true;
            StartCoroutine(CastDash(inputVector));
            StartCoroutine(StartDashCooldown());
        }
    }

    public void CastPrimarySpell(int spellIndex)
    {
        if (!primOnCD)
        {
            StartCoroutine(PrimCooldown(controller.PrimarySpell.cooldown));
            MFLSpellManager.current.CastSpell(transform, spellIndex);
        }
    }
    
    public void CastSecondarySpell(int spellIndex)
    {
        if (!secOnCD)
        {
            StartCoroutine(SecCooldown(controller.SecondarySpell.cooldown));
            MFLSpellManager.current.CastSpell(transform, spellIndex);
        }
    }

    public void ResetPlayerPosition()
    {
        rBody.velocity = Vector3.zero;
        gameObject.transform.position = spawnPoint.transform.position;
        gameObject.transform.rotation = spawnPoint.transform.rotation;
    }
    
    private bool CheckForGrounded()
    {
        RaycastHit hit;
        
        
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastExtension))
        {
            
            
            if (hit.transform.CompareTag("Ground"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }

    public IEnumerator CastDash(Vector2 inputVector)
    {
        Vector3 inputLocalSpace = transform.forward * inputVector.y + transform.right * inputVector.x;
        rBody.AddForce(inputLocalSpace * dashForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        rBody.velocity = Vector3.zero;
    }
    
    public IEnumerator StartDashCooldown()
    {
        
        yield return new WaitForSeconds(dashCooldown);
        dashOnCD = false;
    }
    
    private IEnumerator PrimCooldown(float c)
    {
        primOnCD = true;
        float startTime = Time.time;
        while (Time.time - c < startTime)
        {
            yield return new WaitForEndOfFrame();
        }

        primOnCD = false;
    }
    
    private IEnumerator SecCooldown(float c)
    {
        secOnCD = true;
        float startTime = Time.time;
        while (Time.time - c < startTime)
        {
            yield return new WaitForEndOfFrame();
        }

        secOnCD = false;
    }
    
    
    #endregion

    
    
    
    
}