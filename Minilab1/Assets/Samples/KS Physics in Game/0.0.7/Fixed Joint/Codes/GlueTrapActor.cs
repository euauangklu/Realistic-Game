using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueTrapActor : MonoBehaviour
{
    FixedJoint _fixedJoint = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        GameObject go = collision.gameObject;
        GlueTrap gluetrap = go.GetComponent<GlueTrap>();
        if(gluetrap != null){
            _fixedJoint = this.gameObject.AddComponent<FixedJoint>();
            _fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            Invoke("ReleaseFixedJoint",gluetrap.TimeToSetFree);
        }
    }

    void ReleaseFixedJoint(){
        _fixedJoint.connectedBody = null;
        Destroy(_fixedJoint);
    }
}
