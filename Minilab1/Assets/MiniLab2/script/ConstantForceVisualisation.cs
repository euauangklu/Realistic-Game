using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForceVisualisation : VectorVisualisation
{
    // Start is called before the first frame update
    [SerializeField] protected ConstantForce mConstantForce;
    
     protected override void Start()
         {
         base.Start();
        
         if(mConstantForce== null)
             {
             mConstantForce=GetComponentInParent<ConstantForce>();
             }
         }

 protected override void FixedUpdate()
 {
     Vector3 forceStartPoint=mRigidbody.position;
    
     if(mConstantForce.enabled)
         {
         forceStartPoint=mRigidbody.position-mConstantForce.force;
         }
    
     lineRenderer.SetPosition(0,forceStartPoint);
     lineRenderer.SetPosition(1,mRigidbody.position);
     }
 }
