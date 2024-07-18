using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsulePlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float m_RotationSpeed = 180;
    [SerializeField] protected float m_DirectionalSpeed = 3;
    [SerializeField] protected float m_DirectionalSprintSpeed = 5;

    [Header("Keys Config")] [SerializeField]
    protected Key m_ForwardKey = Key.W;

    [SerializeField] protected Key m_BackwardKey = Key.S;
    [SerializeField] protected Key m_TurnLeftKey = Key.A;
    [SerializeField] protected Key m_TurnRightKey = Key.D;

    protected virtual void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard[m_TurnLeftKey].isPressed)
        {
            transform.Rotate(transform.up, -m_RotationSpeed * Time.deltaTime, Space.Self);
        }
        else if (keyboard[m_TurnRightKey].isPressed)
        {
            transform.Rotate(transform.up, m_RotationSpeed * Time.deltaTime, Space.Self);
        }

        float speedMagnitude = m_DirectionalSpeed;
        if (keyboard[Key.LeftShift].isPressed)
        {
            speedMagnitude = m_DirectionalSprintSpeed;
        }

        if (keyboard[m_ForwardKey].isPressed)
        {
            transform.Translate(transform.forward * speedMagnitude * Time.deltaTime, Space.World);
        }
        else if (keyboard[m_BackwardKey].isPressed)
        {
            //move backward speed is less than normal speed by 60%
            transform.Translate(-transform.forward * (speedMagnitude * 0.4f) * Time.deltaTime, Space.World);
        }
    }
}
