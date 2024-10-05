using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityVisualisation : VectorVisualisation
{
    // Start is called before the first frame update
    protected void FixedUpdate()
         {
         base.FixedUpdate();
        
         Vector3 velocityEndPoint = mRigidbody.position+mRigidbody.velocity;
        
         lineRenderer.SetPosition(0,mRigidbody.position);
         lineRenderer.SetPosition(1, velocityEndPoint);
         }
 }
