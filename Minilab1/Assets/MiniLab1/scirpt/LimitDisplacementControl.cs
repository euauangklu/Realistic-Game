using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VelocityControl))]
public class LimitDisplacementControl : MonoBehaviour
{

    [SerializeField] private float m_MaximumDisplacement;

    private float m_CurrentDisplacement;

    // Use this for initialization
    void Start()
    {
        m_CurrentDisplacement = 0;
    }

    // Update is called once per frame
    void Update()
    {
        VelocityControl vc = GetComponent<VelocityControl>();
        Vector3 v = vc.Velocity;
        // Calculate the accumulated distance
        m_CurrentDisplacement += (v * Time.deltaTime).magnitude;
        if (m_CurrentDisplacement >= m_MaximumDisplacement)
        {
            //Reset the counter
            m_CurrentDisplacement = 0;
            //Inverse the velocity
            v *= -1;
            //Set the new inversed velocity
            vc.Velocity = v;
        }
    }
}
     
