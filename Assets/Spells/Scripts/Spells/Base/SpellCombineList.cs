using System;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

public class SpellCombineList : MonoBehaviour
{
    public SpellCombinations spellCombinations;

    public Dictionary<GameObject,GameObject> nextCombiningSpells = new Dictionary<GameObject, GameObject>();
    public Dictionary<GameObject,GameObject> combiningSpells = new Dictionary<GameObject, GameObject>();
    
    
    public Dictionary<GameObject, Vector3> collisionPositions = new Dictionary<GameObject, Vector3>();
    
    public static SpellCombineList instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        combiningSpells.Clear();
        foreach (var nSp in nextCombiningSpells)
        {
            if (!(combiningSpells.ContainsKey(nSp.Value) && combiningSpells.ContainsValue(nSp.Key)) &&
                !(combiningSpells.ContainsKey(nSp.Key) && combiningSpells.ContainsValue(nSp.Value)))
            {
                combiningSpells.Add(nSp.Key, nSp.Value);
            }
        }
        Debug.Log("next combining count: " + nextCombiningSpells.Count + " current count: " + combiningSpells.Count);

        nextCombiningSpells.Clear();

        foreach (var cSp in combiningSpells)
        {
            CheckCombination(cSp.Key.GetComponent<SpellComponent>().spell,cSp.Key,cSp.Value.GetComponent<SpellComponent>().spell,cSp.Value);
        }
        
        
    }

    public void CheckCombination(Spell sp1, GameObject sg1, Spell sp2, GameObject sg2)
    {
        if (spellCombinations.dictionary.ContainsKey(sp1))
        {
            Debug.Log("One If");
            if (spellCombinations.dictionary[sp1].resultDictionary.ContainsKey(sp2))
            {
                
                Debug.Log("Two If");
                if (spellCombinations.dictionary[sp1].resultDictionary[sp2].destroySpell1)
                {
                    Destroy(sg1);
                }

                if (spellCombinations.dictionary[sp1].resultDictionary[sp2].destroySpell2)
                {
                    Destroy(sg2);
                }

                Vector3 pos = sg1.transform.position;
                if (spellCombinations.dictionary[sp1].resultDictionary[sp2].isTakingSpell2Position)
                {
                    pos = sg2.transform.position;
                }


                GameObject sp = Instantiate(spellCombinations.dictionary[sp1].resultDictionary[sp2].spell.prefab, pos, Quaternion.identity);
                sp.GetComponent<SpellComponent>().CastSpell(Vector3.zero);
            }
        }
        else if (spellCombinations.dictionary.ContainsKey(sp2))
        {
            Debug.Log("One If");
            if (spellCombinations.dictionary[sp2].resultDictionary.ContainsKey(sp1))
            {
                Debug.Log("Two If");
                if (spellCombinations.dictionary[sp2].resultDictionary[sp1].destroySpell1)
                {
                    Destroy(sg1);
                }

                if (spellCombinations.dictionary[sp2].resultDictionary[sp1].destroySpell2)
                {
                    Destroy(sg2);
                }
                
                Vector3 pos = sg2.transform.position;
                if (spellCombinations.dictionary[sp2].resultDictionary[sp1].isTakingSpell2Position)
                {
                    pos = sg1.transform.position;
                }
                
                GameObject sp = Instantiate(spellCombinations.dictionary[sp2].resultDictionary[sp1].spell.prefab, pos, Quaternion.identity);
                sp.GetComponent<SpellComponent>().CastSpell(Vector3.zero);
            }
        }
    }
}




[Serializable]
public class SpellCombineDictionary : SerializableDictionaryBase<Spell, CombinationResult> { }

[Serializable]
public class CombinationResult
{
    
    [SerializeField]
    public SpellCombineResultDictionary resultDictionary = new SpellCombineResultDictionary();
}

[Serializable]
public class SpellResult
{
    public bool destroySpell1;
    public bool destroySpell2;

    public bool isTakingSpell2Position;

    public Spell spell;
}

[Serializable]
public class SpellCombineResultDictionary : SerializableDictionaryBase<Spell, SpellResult> { }

