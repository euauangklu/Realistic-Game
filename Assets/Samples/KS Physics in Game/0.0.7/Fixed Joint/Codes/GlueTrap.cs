using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GlueTrap : MonoBehaviour
{
    [SerializeField]
    float _timeToSetFree = 3;
    public float TimeToSetFree { get => _timeToSetFree; set => _timeToSetFree = value; }

    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
