using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleForceField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float m_ForceFieldMagnitude=40;
    [SerializeField] protected Vector3 m_ForceFieldDirection=Vector3.up;
    
     private void OnTriggerStay(Collider other)
         {
         Rigidbody rb=other.GetComponent<Rigidbody>();
         if(rb!= null)
             {
             rb.AddForce(m_ForceFieldDirection*m_ForceFieldMagnitude);
             }
         }
 }
