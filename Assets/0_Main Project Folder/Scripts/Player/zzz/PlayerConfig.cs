using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfig : MonoBehaviour
{
    public PlayerInput input { get; set; }

    public int pIndex { get; set; }

    public bool isReady { get; set; }

    public Material pMaterial { get; set; }

    public Vector3 pScale { get; set; }

    public PlayerConfig(PlayerInput pi)
    {
        pIndex = pi.playerIndex;
        input = pi;
    }
}