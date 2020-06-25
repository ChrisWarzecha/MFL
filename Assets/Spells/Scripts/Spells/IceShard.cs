using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : SpellComponent
{
    public float speed;
    public float destroyAfter;
    private Rigidbody rigidbody;
    
    public List<GameObject> spawnOnTriggerEnter = new List<GameObject>();
    
    public override IEnumerator ExecuteSpell(Vector3 direction)
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward*speed,ForceMode.Impulse);
        
        float startTime = Time.time;
        while (Time.time - destroyAfter < startTime)
        {
            
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }


    public override void OnTriggerEnterCall(Collider other)
    {
        foreach (GameObject g in spawnOnTriggerEnter)
        {
            Instantiate(g, transform.position, transform.rotation);
        }
    }
}
