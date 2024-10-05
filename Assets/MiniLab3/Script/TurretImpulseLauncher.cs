using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretImpulseLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected bool m_IsDrawGizmos = true;
    [SerializeField] protected float m_LineSize = 0.2f;
    [SerializeField] protected Material m_LineMaterial;
    [SerializeField] protected Transform m_TurretLaunchPosition;
    [SerializeField] protected GameObject m_MissilePrefab;
    [SerializeField] protected float m_Power = 20;
    [SerializeField] protected float m_CoolDownPeriod = 1;
    [SerializeField] protected float m_CurrentCoolDown = 0;
    protected LineRenderer m_LineRenderer;

    private void Start()
    {
        m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        if (m_LineMaterial != null)
        {
            m_LineRenderer.material = m_LineMaterial;
        }

        m_LineRenderer.startWidth = m_LineSize;
        m_LineRenderer.endWidth = 0;
        m_LineRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            m_CurrentCoolDown = 0;
             m_LineRenderer.enabled = true;
        }
    }
    
     private void OnTriggerStay(Collider other)
         {
         if (other.CompareTag("Player"))
             {
             //reduce coolDown
             m_CurrentCoolDown-= Time.deltaTime;
            
             //Laser aiming at player
             m_LineRenderer.SetPosition(0,m_TurretLaunchPosition.position);
             m_LineRenderer.SetPosition(1,other.transform.position); 
             if (m_CurrentCoolDown<=0)
                 {
                 m_CurrentCoolDown = m_CoolDownPeriod;
                 LaunchBall(other.transform.position);
                 }
             }
         }

 private void OnTriggerExit(Collider other)
 {
     if (other.CompareTag("Player"))
         {
         m_LineRenderer.enabled = false;
         }
     }

 private void LaunchBall(Vector3 targetPosition) {
     GameObject go = Instantiate(m_MissilePrefab);
     go.transform.position = m_TurretLaunchPosition.position;
     Rigidbody rb = go.GetComponent<Rigidbody>();
     if (rb is null)
         { 
             rb = go.AddComponent<Rigidbody>();
    }
     Vector3 launchDirection = (targetPosition- m_TurretLaunchPosition.position).normalized;
     if (rb is not null) rb.AddForce(launchDirection * m_Power, ForceMode.Impulse);
     Destroy(go,5);
      }

 private void OnDrawGizmos()
 {
     if(!m_IsDrawGizmos) return;
    
     Gizmos.color = Color.yellow;
    
     if(m_TurretLaunchPosition is not null)
         Gizmos.DrawSphere(m_TurretLaunchPosition.position,0.25f);
     }
 }
 
