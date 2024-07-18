using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGravityImpulseField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float m_ForceFieldMagnitude=100;
    
     private void OnTriggerStay(Collider other)
         {
         Rigidbody rb=other.GetComponent<Rigidbody>();
         if(rb!= null)
             {
             Vector3 v=transform.position- other.transform.position;
             v.Normalize();
             rb.AddForce(v*m_ForceFieldMagnitude,ForceMode.Impulse);
             }
         }
 }
