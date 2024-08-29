using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodFingerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float m_PokeImpulseForceMagnitude = 10;
    [SerializeField] protected float m_PokeNormalForceMagnitude = 5;
    [SerializeField] protected float m_BallImpulseForce = 5;
    private bool _IsLeftAltHeld, _IsLeftCtrlHeld;

    // Use this for initialization
    void Start()
    {

    }

// Update is called once per frame
    protected virtual void Update()
    {
        _IsLeftAltHeld = Input.GetKey(KeyCode.LeftAlt);
        _IsLeftCtrlHeld = Input.GetKey(KeyCode.LeftControl);
        if (Input.GetMouseButtonDown(0))
        {
            ProcessLeftMouseClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ProcessRightMouseClick();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            ProcessMiddleMouseClick();
        }
    }

    private void ProcessLeftMouseClick()
    {
        //A RaycastHit information object
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {
                Vector3 rayDir = ray.direction;
                rayDir = rayDir.normalized;
                if (!_IsLeftCtrlHeld)
                {
                    hit.rigidbody.AddForceAtPosition(rayDir * m_PokeImpulseForceMagnitude, hit.point, ForceMode.Impulse);
                    Utilities.CreateVectorGameObjectAt(hit.point, rayDir, m_PokeImpulseForceMagnitude, 3);
                }
                else
                {
                    hit.rigidbody.AddForceAtPosition(-rayDir* m_PokeImpulseForceMagnitude, hit.point,ForceMode.Impulse);
                    Utilities.CreateVectorGameObjectAt(hit.point, -rayDir, m_PokeImpulseForceMagnitude, 3);
                }
            }
        }
    }


    private void ProcessRightMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Shoot a bullet if left alt is being held
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = ray.origin;
        go.transform.rotation = Quaternion.identity;

        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        go.GetComponent<Rigidbody>().AddForce(ray.direction.normalized * m_BallImpulseForce, ForceMode.Impulse);
        Destroy(go, 3);

    }

    private void ProcessMiddleMouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {
                Vector3 hitNormal = hit.normal;
                hitNormal.Normalize();

                if (!_IsLeftCtrlHeld)
                {
                    hit.rigidbody.AddForceAtPosition(hitNormal * m_PokeImpulseForceMagnitude, hit.point, ForceMode.Impulse);
                    Utilities.CreateVectorGameObjectAt(hit.point, hitNormal, m_PokeImpulseForceMagnitude, 3);
                }
                else
                {
                    hit.rigidbody.AddForceAtPosition(-hitNormal* m_PokeImpulseForceMagnitude, hit.point,ForceMode.Impulse);
                    Utilities.CreateVectorGameObjectAt(hit.point, -hitNormal, m_PokeImpulseForceMagnitude, 3);
                }

            }
        }
    }
}
