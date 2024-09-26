using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneReleaseObjectMechanic : MonoBehaviour
{
    [SerializeField] private FixedJoint fixedJoint;



    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fixedJoint.connectedBody = null;
            Destroy(fixedJoint);
        }
    }
    
    
}
