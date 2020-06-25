using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Resources;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class RelicController : MonoBehaviour
{
   public bool isCarried = false;

   private Rigidbody rBodyOfParent;


   public float speed = 400.0f;

   public float dropImpulse = 300f;

   //public int predictionStepsPerFrame = 6;

   //public Vector3 relicVelocity;

   private Camera playerCam;

   [SerializeField] private Transform relicSpawnPoint;
   

   private void Awake()
   {
      rBodyOfParent = gameObject.transform.parent.GetComponent<Rigidbody>();
   }

   private void Start()
   {
      //relicVelocity = this.transform.forward * speed;
      MFLEventManager.current.OnRelicThrown += OnRelicThrown;
      MFLEventManager.current.OnRelicDropped += OnRelicDropped;
      MFLEventManager.current.OnResetRound += OnResetRound;
   }

   /*
   private void FixedUpdate()
   {
      Vector3 point1 = transform.position;
      float stepSize = 1.0f / predictionStepsPerFrame;
      
      for (float step = 0; step < 1; step += stepSize)
      {
         //hier könnte man auch eine Funktion aufrufen, die komplexere Physicberechnungen, wie zB Wind, macht.
         relicVelocity += Physics.gravity * stepSize * Time.fixedDeltaTime;
         
         Vector3 point2 = point1 + relicVelocity * stepSize * Time.fixedDeltaTime;
         
         Ray ray = new Ray(point1, point2 - point1);
         if (Physics.Raycast(ray, (point2 - point1).magnitude))
         {
            Debug.Log("Hit");
         }
         point1 = point2;
      }
      this.transform.position = point1;
   } */

   public void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player") && !isCarried)
      {
         isCarried = true;

         playerCam = other.GetComponentInChildren<Camera>();
         
         //mach parenting shit, damit relic player folgt
         gameObject.transform.parent.parent = other.GetComponent<PlayerActions>().RelicTargetPosition;
         rBodyOfParent.isKinematic = true;
         gameObject.transform.parent.gameObject.transform.localPosition = Vector3.zero;
         gameObject.transform.parent.gameObject.transform.localRotation = Quaternion.identity;

         int pi = other.GetComponent<PlayerActions>().GetPlayerIndex();
         MFLEventManager.current.RelicPickedUp(pi);
      }
   }

   public void OnRelicThrown()
   {
      transform.parent.transform.parent = null;
      rBodyOfParent.isKinematic = false;
      rBodyOfParent.AddForce(playerCam.transform.forward * speed, ForceMode.Impulse);

      isCarried = false;
   }
   
   public void OnRelicDropped()
   {
      transform.parent.transform.parent = null;
      rBodyOfParent.isKinematic = false;
      rBodyOfParent.AddForce(Vector3.up * dropImpulse, ForceMode.Impulse);

      isCarried = false;
   }

   public void OnResetRound()
   {
      ResetRelicPosition();
   }

   private void ResetRelicPosition()
   {
      rBodyOfParent.velocity = Vector3.zero;
      transform.parent.gameObject.transform.position = relicSpawnPoint.transform.position;
   }
   

   /*
   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Vector3 point1 = this.transform.position;
      Vector3 predictedRelicVelocity = relicVelocity;
      float stepSize = 0.01f;
      for (float step = 0; step < 1; step += stepSize)
      {
         predictedRelicVelocity += Physics.gravity * stepSize;
         Vector3 point2 = point1 + predictedRelicVelocity * stepSize;
         Gizmos.DrawLine(point1, point2);
         point1 = point2;
      }
   } */
}
