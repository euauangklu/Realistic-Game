using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Transform m_LaunchPosition;
    [SerializeField] protected GameObject m_ProjectilePrefab;
    [SerializeField] protected float m_Mass = 1;
    [SerializeField] protected float m_Power = 10;
    [SerializeField] protected CollisionDetectionMode m_CollisionDetectionMode = CollisionDetectionMode.Discrete;
    [SerializeField] protected Key m_KeyToLaunch = Key.E;

    protected virtual void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard[m_KeyToLaunch].wasPressedThisFrame)
        {
            LaunchProjectile();
        }
    }

    public virtual void LaunchProjectile()
    {
        var g = Instantiate(m_ProjectilePrefab);
        g.transform.position = m_LaunchPosition.position;
        var rb = g.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = g.AddComponent<Rigidbody>();
        }

        rb.mass = m_Mass;
        rb.collisionDetectionMode = m_CollisionDetectionMode;
        rb.AddForce(m_LaunchPosition.forward * m_Power, ForceMode.Impulse);
    }
}
