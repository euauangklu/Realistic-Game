using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVectorGizmos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Vector3 m_StartPosition;

    public Vector3 StartPosition
    {
        get { return m_StartPosition; }
        set { m_StartPosition = value; }
    }

    [SerializeField] protected Vector3 m_Direction;

    public Vector3 Direction
    {
        get { return m_Direction; }
        set { m_Direction = value; }
    }

    [SerializeField] protected float m_Length = 1.0f;

    public float Length
    {
        get { return m_Length; }
        set { m_Length = value; }
    }

    [SerializeField] private Color _color = Color.white;

    public Color LineColor
    {
        set { _color = value; }
    }

    private float _arrowHeadAngle = 20.0f;
    private float _arrowHeadLength = 0.25f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(_startPosition.position, _endPosition.position, _color);
    }

    private void OnDrawGizmos()
    {
        if (m_StartPosition != null && m_Direction != null)
        {
            Vector3 endPosition = (m_StartPosition) + (m_Direction.normalized * m_Length);

            Gizmos.color = _color;
            Gizmos.DrawLine(m_StartPosition, endPosition);

            Vector3 right = Quaternion.LookRotation(m_Direction) * Quaternion.Euler(0, 180 + _arrowHeadAngle, 0) *
                            new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(m_Direction) * Quaternion.Euler(0, 180 - _arrowHeadAngle, 0) *
                           new Vector3(0, 0, 1);
            Gizmos.DrawRay(endPosition, right * _arrowHeadLength);
            Gizmos.DrawRay(endPosition, left * _arrowHeadLength);
        }
    }
}
