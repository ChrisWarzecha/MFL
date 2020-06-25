using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandstorm_Sandstorm : SpellComponent
{

    public float destroyAfter;
    
    public override IEnumerator ExecuteSpell(Vector3 direction)
    {
        yield return new WaitForSeconds(destroyAfter);
        Destroy(gameObject);
    }

    public override void OnTriggerEnterCall(Collider other)
    {
        
    }
}