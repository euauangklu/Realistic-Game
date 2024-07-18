using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float m_ImpulsePower = 10;
    [SerializeField] protected float m_Radius = 3;
    [SerializeField] protected float m_TimeToExplode = 3;
         protected bool _IsTimerStart;
         protected float _StartTimeStamp;
         protected float _EndTimeStamp;
        
         private void OnEnable()
         {
         _IsTimerStart = true;
         _StartTimeStamp = Time.time;
         _EndTimeStamp = Time.time + m_TimeToExplode;
         }

 private void Update()
 {
     if (!_IsTimerStart) return;
    
     if (Time.time >=_EndTimeStamp)
     { 
             Explode();
     }
    }
 
  protected void Explode()
      {
      Vector3 explosionPos = transform.position;
      Collider[] colliders = Physics.OverlapSphere(explosionPos, m_Radius);
      foreach (Collider hit in colliders)
      {
          Rigidbody rb = hit.GetComponent<Rigidbody>();
         
          if (rb != null){
             
              rb.AddExplosionForce(m_ImpulsePower, explosionPos, m_Radius,
                  3.0f,ForceMode.Impulse);
          }
      }
     
      Destroy(gameObject, 0);
      }
}
