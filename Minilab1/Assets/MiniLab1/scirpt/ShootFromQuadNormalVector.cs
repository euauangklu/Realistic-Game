using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootFromQuadNormalVector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string m_QuadName = "Quad";
    private Vector3 m_Speed = Vector3.zero;
    [SerializeField] private float m_DesireSpeedMagnitude = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += m_Speed;

        if (Input.GetMouseButtonDown(0))
        {
            //Find the "Quad" game object
            GameObject quad = GameObject.Find(m_QuadName);
            Mesh mesh = quad.GetComponent<MeshFilter>().mesh;
            //Get a list of vertices from the mesh
            List<Vector3> vertices = new List<Vector3>();
            mesh.GetVertices(vertices);

            //Use 2 vectors from the mesh vertices to calculate normal vector by using vector cross product
            Vector3 v1 = quad.transform.TransformPoint(vertices[0]) - quad.transform.TransformPoint(vertices[1]);
            Vector3 v2 = quad.transform.TransformPoint(vertices[0]) - quad.transform.TransformPoint(vertices[2]);
            Vector3 vNormal = Vector3.Cross(v1, v2).normalized;

            //Use the calculated result (normal vector) as the object movingspeed
            m_Speed = vNormal * m_DesireSpeedMagnitude;
            transform.position = quad.transform.position;
        } //Get mesh from the Quad game object

        
    }
}
