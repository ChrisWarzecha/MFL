using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering.HDPipeline;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private int teamIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Relic"))
        {
            CustomEventManager.current.GoalScored(teamIndex);
        }
    }
}
