using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLauncherOnLerpSlerp : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Launcher Settings")] [SerializeField]
    protected Transform m_Origin;

    [SerializeField] protected Transform m_A;
    [SerializeField] protected Transform m_B;
    [SerializeField] protected float m_PointMovingSpeed = .5f;
    [SerializeField] protected float m_LaunchInterval = .1f;
    [SerializeField] protected bool m_LerpOrSlerp = true;
    private Vector3 _InterpolatedPosition;

    [Header("Prefab Settings")] [SerializeField]
    protected GameObject m_PrefabToBeLaunched;

    [SerializeField] protected float m_ForceMagnitude = 20;
    [SerializeField] protected float m_LifeTime = 1.5f;
    protected bool m_IsIncrement = false;
    [SerializeField] protected float m_T;
    [Header("Gizmos")] [SerializeField] protected bool m_IsDrawGizmos = true;

    private void Start()
    {
        Invoke(nameof(LaunchBall), 0);
    }

    private void Update()
    {
        if (m_IsIncrement)
        {
            m_T += m_PointMovingSpeed * Time.deltaTime;

            if (m_T >= 1)
            {
                m_IsIncrement = false;
            }
        }
        else
        {
            m_T -= m_PointMovingSpeed * Time.deltaTime;
        }

        if (m_T <= 0)
        {
            m_IsIncrement = true;
        }

        if (m_LerpOrSlerp)
        {
            _InterpolatedPosition = Vector3.Lerp(m_A.position, m_B.position,
                m_T);
        }
        else
        {
            _InterpolatedPosition = Vector3.Slerp(m_A.position, m_B.position,
                m_T);
        }
    }


    private void LaunchBall()
    {
        GameObject go = Instantiate(m_PrefabToBeLaunched);
        go.transform.position = m_Origin.position;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb is null)
        {
            rb = go.AddComponent<Rigidbody>();
        }

        Vector3 launchDirection = (_InterpolatedPosition - m_Origin.position).normalized;
        if (rb is not null)
            rb.AddForce(launchDirection * m_ForceMagnitude,
                ForceMode.Impulse);
        Destroy(go, m_LifeTime);
        Invoke(nameof(LaunchBall), m_LaunchInterval);
    }

    private void OnDrawGizmos()
    {
        if (!m_IsDrawGizmos) return;
        Gizmos.color = Color.magenta;
        if (m_A != null)
        {
            Gizmos.DrawSphere(m_Origin.position, 0.5f);
        }

        Gizmos.color = Color.cyan;
        if (m_A != null)
        {
            Gizmos.DrawSphere(m_A.position, 0.5f);
        }

        if (m_B != null)
        {
            Gizmos.DrawSphere(m_B.position, 0.5f);
        }

        Gizmos.DrawSphere(_InterpolatedPosition, 0.25f);
        Gizmos.color = Color.yellow;
        if (m_A != null && m_B != null)
        {
            Gizmos.DrawLine(m_A.position, m_B.position);
        }

        if (m_A != null && m_B != null && m_Origin != null)
        {
            Gizmos.DrawLine(m_A.position, m_Origin.position);
            Gizmos.DrawLine(m_B.position, m_Origin.position);
        }

        Gizmos.DrawLine(m_Origin.position, _InterpolatedPosition);
    }
}

 

