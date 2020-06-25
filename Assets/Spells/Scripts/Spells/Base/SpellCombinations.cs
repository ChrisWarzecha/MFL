using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1, fileName = "SpellCombinations", menuName = "Spell Combinations")]
public class SpellCombinations : ScriptableObject
{
    [SerializeField]
    public SpellCombineDictionary dictionary = new SpellCombineDictionary();
}