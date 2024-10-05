using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeForceVisualisation : ConstantForceVisualisation
{
    // Start is called before the first frame update
    protected override void FixedUpdate()
         {
         Vector3 forceStartPoint=mRigidbody.position;
        
         if(mConstantForce.enabled)
             {
             forceStartPoint=mRigidbody.position-mConstantForce.
                relativeForce;
             }
        
         lineRenderer.SetPosition(0,forceStartPoint);
         lineRenderer.SetPosition(1,mRigidbody.position);
        
         }
}
