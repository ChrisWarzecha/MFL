using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConsoleFunctions
{
    [CC]
    public static void ResetRound()
    {
        MFLEventManager.current.ResetRound();
    }

    [CC]
    public static void ResetScore()
    {
        MFLScoreManager.current.scoreTone = 0;

        MFLScoreManager.current.scoreTtwo = 0;
    }
}
