using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehavior : MonoBehaviour
{
    public static TestBehavior instance;
    
    public bool testBool;

    public Vector3 testVector;
    
    public void Awake()
    {
        instance = this;
    }
    
    [CC("Set Test Bool")]
    public static void SetBool(bool test)
    {
        TestBehavior.instance.testBool = test;
    }
    
    [CC("Set Test Vector")]
    public static void SetVector(Vector3 test)
    {
        TestBehavior.instance.testVector = test;
    }
    
    
    
    [CC("Quits the application")]
    public static void QuitGame()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            Application.Quit();
        }
    }
}
