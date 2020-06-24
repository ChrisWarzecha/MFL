using System;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

[CreateAssetMenu( fileName = "Spell",menuName= "",order =0)]
[Serializable]
public class Spell : ScriptableObject 
{
    public GameObject prefab;
    public float cooldown;
}
