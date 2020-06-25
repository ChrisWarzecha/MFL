using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugData
{
    public static bool debugLog;
    public static bool debugEditor;
    public static bool debugInGame;

    public static Action OnEnableLog;
    public static Action OnDisableLog;
    
    public static Action OnEnableEditor;
    public static Action OnDisableEditor;

    public static Action OnEnableInGame;
    public static Action OnDisableInGame;

    [CC("Activate optional Debug Log")]
    public static void SetDebugLog(bool val)
    {
        switch (val)
        {
            case true:
                OnEnableLog?.Invoke();
                break;
            default:
                OnDisableLog?.Invoke();
                break;
        }
        
        debugLog = val;
    }

    [CC("Activate optional Debug Editor")]
    public static void SetDebugEditor(bool val)
    {
        switch (val)
        {
            case true:
                OnEnableEditor?.Invoke();
                break;
            default:
                OnDisableEditor?.Invoke();
                break;
        }
        
        debugEditor = val;
    }

    [CC("Activate optional Debug in Game")]
    public static void SetDebugInGame(bool val)
    {
        switch (val)
        {
            case true:
                OnEnableInGame?.Invoke();
                break;
            default:
                OnDisableInGame?.Invoke();
                break;
        }
        
        debugInGame = val;
    }
}
