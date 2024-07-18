using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSlerp : MonoBehaviour
{
    [SerializeField] private Transform m_A;
    [SerializeField] private Transform m_B;
    [SerializeField] private Transform m_MovingObjectLERP;
    [SerializeField] private Transform m_MovingObjectSLERP;
    [SerializeField] [Range(0,1)] private float m_t = 0;
         private LineRenderer m_LineRenderer;
         private void Start()
         {
         m_LineRenderer = gameObject.AddComponent <LineRenderer >();
         m_LineRenderer.widthCurve = AnimationCurve.Constant(0,1,0.1f);
        
         m_LineRenderer.SetPosition(0,m_A.transform.position);
         m_LineRenderer.SetPosition(1,m_B.transform.position);
         }
 private void Update()
 {
     m_MovingObjectLERP.position = Vector3.Lerp(m_A.position,m_B.position, m_t);
     m_MovingObjectSLERP.position= Vector3.Slerp(m_A.position,m_B.position, m_t);
     }
 private void OnDrawGizmos()
 {Gizmos.color = Color.cyan;
     
      if (m_A != null){
          Gizmos.DrawSphere(m_A.position ,0.5f);
      }
      if (m_B != null){
          Gizmos.DrawSphere(m_B.position ,0.5f);
      }
     
      Gizmos.color = Color.yellow;
      if (m_A != null && m_B != null){
          Gizmos.DrawLine(m_A.position, m_B.position);
          }
      }
  }

