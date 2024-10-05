using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class AlwaysFacingCameraComponent : MonoBehaviour
{
    public Camera m_Camera;

    public void Start()
    {
        if (m_Camera == null)
        {
            m_Camera = Camera.main;
        }

        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = m_Camera;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation *
            Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
