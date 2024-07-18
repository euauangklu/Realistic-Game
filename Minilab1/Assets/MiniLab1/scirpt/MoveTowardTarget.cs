using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardTarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string m_TargetName = "Cube";
    [SerializeField] private Vector3 m_Speed = Vector3.zero;
    [SerializeField] private float m_DesireSpeedMagnitude=0.02f;
    private bool m_TargetTracking = true;
        // Update is called once per frame
        void Update()
        {
            transform.position += m_Speed;
            if (Input.GetMouseButtonDown(0))
            {
                m_TargetTracking = !m_TargetTracking;
                if (!m_TargetTracking)
                {
                    m_Speed = Vector3.zero;
                }
            }

            if (m_TargetTracking)
            {
                //Find the target
                GameObject targetGameObject = GameObject.Find(m_TargetName); //Get the target position
                Vector3 targetPosition = targetGameObject.transform.position; //Calculate vector to the target
                Vector3 vecToCubeNorm = targetPosition - transform.position;
                vecToCubeNorm.Normalize();
                m_Speed = vecToCubeNorm * m_DesireSpeedMagnitude;
            }
        }

}
