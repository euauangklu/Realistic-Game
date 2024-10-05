using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PressKeyToAddTorque : MonoBehaviour
{
    [SerializeField] KeyEventSettings m_KeySettings;

    [SerializeField] TorqueSettings m_TorqueSettings;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_KeySettings.TypeOfKeyEventToCapture)
        {
            case TypeOfKeyEvent.KEYDOWN:
                if (Input.GetKeyDown(m_KeySettings.KeycodeToActivate))
                {
                    Rigidbody rb = this.GetComponent<Rigidbody>();
                    if (m_TorqueSettings.IsGlobal)
                    {
                        rb.AddTorque(m_TorqueSettings.TorqueAxis.normalized * m_TorqueSettings.AmountOfTorque,
                            m_TorqueSettings.ForceMode);
                    }
                    else
                    {
                        rb.AddRelativeTorque(m_TorqueSettings.TorqueAxis.normalized * m_TorqueSettings.AmountOfTorque,
                            m_TorqueSettings.ForceMode);
                    }
                }

                break;
            case TypeOfKeyEvent.KEYHOLD:
                if (Input.GetKey(m_KeySettings.KeycodeToActivate))
                {
                    Rigidbody rb = this.GetComponent<Rigidbody>();
                    if (m_TorqueSettings.IsGlobal)
                    {
                        rb.AddTorque(m_TorqueSettings.TorqueAxis.normalized *
                                     m_TorqueSettings.AmountOfTorque,
                            m_TorqueSettings.ForceMode);
                    }
                    else
                    {
                        rb.AddRelativeTorque(m_TorqueSettings.TorqueAxis.normalized * m_TorqueSettings.AmountOfTorque,
                            m_TorqueSettings.ForceMode);
                    }
                }

                break;
            case TypeOfKeyEvent.KEYUP:
                if (Input.GetKeyUp(m_KeySettings.KeycodeToActivate))
                {
                    Rigidbody rb = this.GetComponent<Rigidbody>();
                    if (m_TorqueSettings.IsGlobal)
                    {
                        rb.AddTorque(m_TorqueSettings.TorqueAxis.normalized *
                                     m_TorqueSettings.AmountOfTorque,
                            m_TorqueSettings.ForceMode);
                    }
                    else
                    {
                        rb.AddRelativeTorque(m_TorqueSettings.TorqueAxis.normalized * m_TorqueSettings.AmountOfTorque,
                            m_TorqueSettings.ForceMode);
                    }
                }

                break;

        }
    }
}
