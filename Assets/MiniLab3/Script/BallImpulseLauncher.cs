using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallImpulseLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float m_Mass;
    [SerializeField] protected float m_ForceMagnitude;
    [SerializeField] protected float m_LaunchInterval;
    [SerializeField] protected float m_LifeTime = 3;

    // Use this for initialization
    private void Start()
    {
        Invoke("LaunchBall", m_LaunchInterval);
    }

    private void LaunchBall()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = this.transform.position;
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.mass = m_Mass;
        rb.AddForce(this.transform.forward * m_ForceMagnitude, ForceMode.Impulse);
        Destroy(go, m_LifeTime);
        Invoke("LaunchBall", m_LaunchInterval);
    }
}
