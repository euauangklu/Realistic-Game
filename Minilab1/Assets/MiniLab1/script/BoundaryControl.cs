
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    // Start is called before the first frame update
    [RequireComponent(typeof(VelocityControl))]
    public class BoundaryControl : MonoBehaviour
    { 
        [SerializeField] private float m_BoundaryConst = 5.0f;
        
        // Update is called once per frame
        void Update()
        {
            Vector3 pos = transform.position;
            VelocityControl vc = GetComponent<VelocityControl>();
            Vector3 tmpVelocity = vc.Velocity;
            if (pos.x >= m_BoundaryConst || pos.x <= -m_BoundaryConst)
            {
                tmpVelocity.x *= -1;
                vc.Velocity = tmpVelocity;
            } 
            if (pos.y >= m_BoundaryConst || pos.y <= -m_BoundaryConst)
            {
                tmpVelocity.y *= -1;
                vc.Velocity = tmpVelocity;
            } 
            if (pos.z >= m_BoundaryConst || pos.z <= -m_BoundaryConst)
            { 
                tmpVelocity.z *= -1; 
                vc.Velocity = tmpVelocity; 
            }
        }
    }

