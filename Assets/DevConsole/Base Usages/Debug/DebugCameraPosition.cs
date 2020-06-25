using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraPosition : MonoBehaviour
{

    public bool debug;
    
    // Start is called before the first frame update
    void Awake()
    {
        DebugData.OnEnableInGame += OnEnableDebug;
        DebugData.OnDisableInGame += OnDisableDebug;
    }

    private void OnEnableDebug()
    {
        debug = true;
    }

    private void OnDisableDebug()
    {
        debug = false;
    }
}
