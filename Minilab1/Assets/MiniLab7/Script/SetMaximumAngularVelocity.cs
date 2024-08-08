using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SetMaximumAngularVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_Rigidbody;

    [SerializeField] [Tooltip("Degrees per second")]
    float m_MaximumAngularVelocity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        m_Rigidbody = rb;
        if (rb != null)
        {

            m_Rigidbody.maxAngularVelocity = m_MaximumAngularVelocity * Mathf.Deg2Rad;
        }
    }

    public void SetMaximumAngularSpeedLimit(float val)
    {
        m_MaximumAngularVelocity = val * Mathf.Deg2Rad;
    }
}
