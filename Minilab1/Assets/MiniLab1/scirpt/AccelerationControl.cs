using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VelocityControl))] 
public class AccelerationControl : MonoBehaviour {
     [SerializeField] private Vector3 m_Acceleration; 
     public Vector3 Acceleration {
     get{
         return m_Acceleration; 
     }
     set{
         m_Acceleration = value;
         }
     }

 // Update is called once per frame
 void Update () {
     if (Input.GetKey(KeyCode.Space))
         {
         VelocityControl vc = GetComponent <VelocityControl >();
         Vector3 v = vc.Velocity;
         v += m_Acceleration * Time.deltaTime;
         vc.Velocity = v;
         }
     }
 }
