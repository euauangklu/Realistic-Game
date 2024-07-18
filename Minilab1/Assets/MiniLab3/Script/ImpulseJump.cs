using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ImpulseJump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Key m_JumpKey = Key.Space;
    [SerializeField] protected float m_JumpMagnitude = 7;
    protected Rigidbody m_Rigidbody;
    protected bool m_IsGround = true;

    protected void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    

    protected void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard[m_JumpKey].wasPressedThisFrame && m_IsGround){
            m_Rigidbody.AddForce(0, m_JumpMagnitude, 0, ForceMode.Impulse);
            m_IsGround = false;
    }
    }

    protected void OnCollisionEnter(Collision other)
    {
        m_IsGround = true;

    }
}

