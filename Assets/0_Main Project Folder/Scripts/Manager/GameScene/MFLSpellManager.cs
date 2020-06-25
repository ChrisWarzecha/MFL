using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MFLSpellManager : MonoBehaviour
{
    public static MFLSpellManager current;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    public Vector2 spellsPlayerOne; // = new Vector2 (1/3) Bei den beiden oberen Spells
    
    public Vector2 spellsPlayerTwo;
    
    public Vector2 spellsPlayerThree;

    public Vector2 spellsPlayerFour;

    public bool onCooldown = false;
    

    //Populate in Inspector with the Scriptable Objects of the Spells
    public Spell[] allSpells;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetSpells(int pIndex, int indexPrimSpell, int indexSecSpell)
    {
        if (pIndex == 0)
        {
            spellsPlayerOne = new Vector2(indexPrimSpell, indexSecSpell);
        }

        if (pIndex == 1)
        {
            spellsPlayerTwo = new Vector2(indexPrimSpell, indexSecSpell);
        }

        if (pIndex == 2)
        {
            spellsPlayerThree = new Vector2(indexPrimSpell, indexSecSpell);
        }
        
        if (pIndex == 3)
        {
            spellsPlayerFour = new Vector2(indexPrimSpell, indexSecSpell);
        }
    }

    public Vector2 GetSpells(int pIndex)
    {
        if (pIndex == 0)
        {
            return spellsPlayerOne;
        }

        if (pIndex == 1)
        {
            return spellsPlayerTwo;
        }

        if (pIndex == 2)
        {
            return spellsPlayerThree;
        }
        
        if (pIndex == 3)
        {
            return spellsPlayerFour;
        }

        return Vector2.zero;
    }

    public void CastSpell(Transform pTransform, int spellIndex)
    {
        //spawn Spell prefab
        GameObject s = Instantiate(allSpells[spellIndex].prefab, pTransform.position + (Vector3)(pTransform.localToWorldMatrix*allSpells[spellIndex].offsetSpawnPosition), pTransform.rotation);
        
        //GetComponent SpellComponent from spawned spellPrefab
        s.GetComponent<SpellComponent>().CastSpell(pTransform.forward);
    }
}
