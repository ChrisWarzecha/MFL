using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class SpellComponent : MonoBehaviour
{
    public Spell spell;
    public Vector3 force;
    
    private List<GameObject> collidedPlayers = new List<GameObject>();

    public void CastSpell(Vector3 direction)
    {
        StartCoroutine(ExecuteSpell(direction));
    }

    public abstract IEnumerator ExecuteSpell(Vector3 direction);

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterCall(other);
        Debug.Log(this.name + " collided with " + other.gameObject.name);
        if (other.GetComponent<SpellComponent>())
        {
            if (!SpellCombineList.instance.nextCombiningSpells.ContainsKey(gameObject) 
                /*&&
                (!(SpellCombineList.instance.nextCombiningSpells.ContainsKey(gameObject) &&
                  SpellCombineList.instance.nextCombiningSpells.ContainsValue(other.gameObject)) &&
                !(SpellCombineList.instance.nextCombiningSpells.ContainsKey(other.gameObject) &&
                  SpellCombineList.instance.nextCombiningSpells.ContainsValue(gameObject)))&&
                (!(SpellCombineList.instance.combiningSpells.ContainsKey(gameObject) &&
                  SpellCombineList.instance.combiningSpells.ContainsValue(other.gameObject)) &&
                !(SpellCombineList.instance.combiningSpells.ContainsKey(other.gameObject) &&
                  SpellCombineList.instance.combiningSpells.ContainsValue(gameObject)))*/
                  )
            {
                SpellCombineList.instance.nextCombiningSpells.Add(gameObject,other.gameObject);
            } 
        }
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Rigidbody>() != null && !collidedPlayers.Contains(other.gameObject))
            {
                collidedPlayers.Add(other.gameObject);
                Debug.Log("PUSH");
                Rigidbody r = other.GetComponent<Rigidbody>();
                
                r.AddForce((Vector3)(transform.localToWorldMatrix*force) ,ForceMode.Impulse);
            }
        }
    }

    public abstract void OnTriggerEnterCall(Collider other);
}
