using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private int indexTeamScoredOn;
    private int goalIndex;

    private bool scored = false;

    private void Start()
    {
        MFLEventManager.current.OnResetRound += ResetGoal;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Relic") && !scored && !other.isTrigger)
        {
            scored = true;
            MFLEventManager.current.GoalScored(indexTeamScoredOn);
        }
    }

    private void ResetGoal()
    {
         scored = false;
    }

    private void OnDestroy()
    {
        MFLEventManager.current.OnResetRound -= ResetGoal;
    }
    
}
