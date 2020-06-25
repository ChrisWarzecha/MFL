using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellUser : MonoBehaviour
{

    public Spell spell;
    public bool onCooldown = false;
    public float speed;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onCooldown)
        {
            StartCoroutine(Cooldown(spell.cooldown));
            GameObject s = Instantiate(spell.prefab, transform.position + transform.forward * 2, Quaternion.identity);
            //spawn Spell prefab
            //GetComponent SpellComponent from spawned spellPrefab
            s.GetComponent<SpellComponent>().CastSpell(transform.forward);
        }
    }
    

    private IEnumerator Cooldown(float c)
    {
        onCooldown = true;
        float startTime = Time.time;
        while (Time.time - c < startTime)
        {
            yield return new WaitForEndOfFrame();
        }

        onCooldown = false;
    }
}
