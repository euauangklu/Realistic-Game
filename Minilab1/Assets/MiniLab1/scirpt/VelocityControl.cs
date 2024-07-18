using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 m_Velocity;
    public Vector3 Velocity{
         get{
         return m_Velocity;
         } 
         set{
         m_Velocity = value;
         }
     }

 // Update is called once per frame
 void Update () {
     transform.position += m_Velocity * Time.deltaTime;
     }
 }
