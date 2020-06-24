using System;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

public class SpellCombineList : MonoBehaviour
{
    [SerializeField]
    public SpellCombineDictionary spellCombineDictionary = new SpellCombineDictionary();

    public Dictionary<GameObject,GameObject> nextCombiningSpells = new Dictionary<GameObject, GameObject>();
    public Dictionary<GameObject,GameObject> combiningSpells = new Dictionary<GameObject, GameObject>();
    
    public static SpellCombineList instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Update()
    {
        combiningSpells.Clear();
        foreach (var nSp in nextCombiningSpells)
        {
            if (!(combiningSpells.ContainsKey(nSp.Value) && combiningSpells.ContainsValue(nSp.Key)))
            {
                combiningSpells.Add(nSp.Key, nSp.Value);
            }
        }

        nextCombiningSpells.Clear();
        foreach (var cSp in combiningSpells)
        {
            CheckCombination(cSp.Key.GetComponent<SpellComponent>().spell,cSp.Key,cSp.Value.GetComponent<SpellComponent>().spell,cSp.Value);
        }
        
    }

    public void CheckCombination(Spell sp1, GameObject sg1, Spell sp2, GameObject sg2)
    {
        if (spellCombineDictionary.ContainsKey(sp1))
        {
            if (spellCombineDictionary[sp1].resultDictionary.ContainsKey(sp2))
            {
                Vector3 pos = sg1.transform.position;
                Destroy(sg1);
                Destroy(sg2);
                GameObject sp = Instantiate(spellCombineDictionary[sp1].resultDictionary[sp2].prefab, pos, Quaternion.identity);
                sp.GetComponent<SpellComponent>().CastSpell(Vector3.zero);
            }
        }
        else if (spellCombineDictionary.ContainsKey(sp2))
        {
            if (spellCombineDictionary[sp2].resultDictionary.ContainsKey(sp1))
            {
                Vector3 pos = sg2.transform.position;
                Destroy(sg2);
                Destroy(sg1);
                GameObject sp = Instantiate(spellCombineDictionary[sp2].resultDictionary[sp1].prefab, pos, Quaternion.identity);
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
public class SpellCombineResultDictionary : SerializableDictionaryBase<Spell, Spell> { }

