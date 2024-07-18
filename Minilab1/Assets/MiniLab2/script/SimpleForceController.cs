using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class SimpleForceController : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] protected float m_UpLiftForceMagnitude=12;
    [SerializeField] protected float m_DirectionalForceMagnitude=5;
    
     protected Rigidbody m_Rigidbody;
    
     private void Start()
         {
         m_Rigidbody=GetComponent<Rigidbody>();
         }

 private void FixedUpdate()
 {
     Keyboard keyboard=Keyboard.current;
    
     if(keyboard[Key.Q].isPressed)
         {
         m_Rigidbody.AddForce(Vector3.up*m_UpLiftForceMagnitude);
         }else if (keyboard[Key.E].isPressed)
         {
         m_Rigidbody.AddForce(Vector3.down*m_UpLiftForceMagnitude);
         } 
     
     if(keyboard[Key.W].isPressed)
         {
         m_Rigidbody.AddForce(Vector3.forward*m_DirectionalForceMagnitude);
         }else if(keyboard[Key.S].isPressed)
         {
         m_Rigidbody.AddForce(Vector3.back*m_DirectionalForceMagnitude);
         }
    
     if(keyboard[Key.A].isPressed)
         {
         m_Rigidbody.AddForce(Vector3.left*m_DirectionalForceMagnitude);
         }else if(keyboard[Key.D].isPressed)
         {
         m_Rigidbody.AddForce(Vector3.right*m_DirectionalForceMagnitude);
         }
    
     }
}
