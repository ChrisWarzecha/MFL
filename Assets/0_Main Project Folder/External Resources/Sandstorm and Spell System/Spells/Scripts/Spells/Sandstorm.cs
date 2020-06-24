using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sandstorm : SpellComponent
{
    public float spellTime = 5;
    public Transform attractor;

    public float force;

    public float rotationSpeed;

    public AnimationCurve movementCurve;
    public float movementSpeed;

    public List<Rigidbody> inRange;

    private Rigidbody rigidbody;


    void Update()
    {
        transform.Rotate(Vector3.up,rotationSpeed*Time.deltaTime);
    }
    
    public override IEnumerator StartSpell(Vector3 direction)
    {
        Vector3 startPosition = transform.position;
        Vector3 currentPos = startPosition;
        
        float startTime = Time.time;
        while (Time.time - spellTime < startTime)
        {
            currentPos = currentPos +  Vector3.Cross(direction.normalized,Vector3.up) * Time.deltaTime * movementCurve.Evaluate(Time.time - startTime) *movementSpeed;
            currentPos = currentPos + direction * Time.deltaTime * movementSpeed;
            transform.position = currentPos;
            
            for (int i = 0; i < inRange.Count; i++)
            {
                if (inRange[i] != null)
                {
                    inRange[i].AddForceAtPosition((attractor.position - inRange[i].position).normalized * force,
                        attractor.position, ForceMode.Acceleration);
                }
            }
            yield return new WaitForEndOfFrame();
        }

        //Destroy This GameObject
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Rigidbody r = other.GetComponent<Rigidbody>();
        if (r != null)
        {
            if (!inRange.Contains(r) && r.CompareTag("Player")) //ask tag
            {
                inRange.Add(r);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Rigidbody r = other.GetComponent<Rigidbody>();
        if (r != null)
        {
            if (inRange.Contains(r) && r.CompareTag("Player")) //ask tag
            {
                inRange.Remove(r);
            }
        }
    }
}
