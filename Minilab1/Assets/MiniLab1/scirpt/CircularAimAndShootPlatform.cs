using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularAimAndShootPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float m_AngleStep = 3;
    [SerializeField] private float m_Length = 2.5f;
    [SerializeField] private float m_CurrentAngle = 90;
         private LineRenderer m_LineRenderer;
         private void Start() {
         m_LineRenderer = gameObject.AddComponent <LineRenderer >();
         m_LineRenderer.widthCurve = AnimationCurve.Constant(0,1,0.1f);
         } 
         // Update is called once per frame
         void Update () {
     float sine = Mathf.Sin(m_CurrentAngle*Mathf.Deg2Rad);
     float cosine = Mathf.Cos(m_CurrentAngle * Mathf.Deg2Rad);
     Vector3 unitCircleDirection = new Vector3(m_Length*cosine,m_Length*sine,0);
     transform.position = unitCircleDirection;
     m_LineRenderer.SetPosition(1,unitCircleDirection);
     if (Input.GetKey(KeyCode.LeftArrow)){
         m_CurrentAngle += m_AngleStep;
         }
     if (Input.GetKey(KeyCode.RightArrow)){
         m_CurrentAngle -= m_AngleStep;
         }
     if (Input.GetKeyDown(KeyCode.Space)){
         GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
         sphere.transform.position = this.transform.position * 1.5f;
         Rigidbody rb = sphere.AddComponent <Rigidbody >();
         rb.useGravity = false;
         rb.AddForce(unitCircleDirection.normalized * 3,ForceMode.Impulse);
         Destroy(sphere ,2);
         }
     }
 }
