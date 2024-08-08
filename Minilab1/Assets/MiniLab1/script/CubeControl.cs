using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace euaungkul.Realistic.Minilab1
{
    public class CubeControl : MonoBehaviour
    {
        [SerializeField] Vector3 m_CubeMovementSpeed = new Vector3(0.03f, 0.05f, 0);

        [SerializeField] private float BOUNDARY = 2.0f;

        // Update is called once per frame
        void Update()
        {
            transform.position += m_CubeMovementSpeed;
            if (transform.position.x >= BOUNDARY || transform.position.x <= -BOUNDARY)
            {
                m_CubeMovementSpeed.x *= -1;
            }

            if (transform.position.y >= BOUNDARY || transform.position.y <= -BOUNDARY)
            {
                m_CubeMovementSpeed.y *= -1;
            }

            if (transform.position.z >= BOUNDARY || transform.position.z <= -BOUNDARY)
            {
                m_CubeMovementSpeed.z *= -1;
            }
        }
    }
}
