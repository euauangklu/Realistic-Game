using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class UIOverHeadSliderRBAngularVelocityInfo : MonoBehaviour
{
    [SerializeField] Text m_Text;

    [SerializeField] Slider m_Slider;

    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float angularVelocityMag = (float)(m_Rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg);

        m_Text.text = angularVelocityMag.ToString("F2");
        m_Slider.value = angularVelocityMag;
    }
}
