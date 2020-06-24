using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public abstract class SpellComponent : MonoBehaviour
{
    public Spell spell;

    public void CastSpell(Vector3 direction)
    {
        StartCoroutine(StartSpell(direction));
    }

    public abstract IEnumerator StartSpell(Vector3 direction);

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<SpellComponent>())
        {
            if ((!(SpellCombineList.instance.nextCombiningSpells.ContainsKey(gameObject) &&
                  SpellCombineList.instance.nextCombiningSpells.ContainsValue(other.gameObject)) &&
                !(SpellCombineList.instance.nextCombiningSpells.ContainsKey(other.gameObject) &&
                  SpellCombineList.instance.nextCombiningSpells.ContainsValue(gameObject)))&&
                (!(SpellCombineList.instance.combiningSpells.ContainsKey(gameObject) &&
                  SpellCombineList.instance.combiningSpells.ContainsValue(other.gameObject)) &&
                !(SpellCombineList.instance.combiningSpells.ContainsKey(other.gameObject) &&
                  SpellCombineList.instance.combiningSpells.ContainsValue(gameObject))))
            {
                SpellCombineList.instance.nextCombiningSpells.Add(gameObject,other.gameObject);
            } 
        }
    }
}
