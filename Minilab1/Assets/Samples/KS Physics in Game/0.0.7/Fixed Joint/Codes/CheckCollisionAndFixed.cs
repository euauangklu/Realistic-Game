using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionAndFixed : MonoBehaviour
{
    [SerializeField]
    bool _isTimerDestroyJoint = false;

    [SerializeField]
    float _timeToDestroyJoint = 1.0f; 

    void OnCollisionEnter(Collision collision){

        ColourMarkerComponent _myCMC = this.GetComponent<ColourMarkerComponent>();
        ColourMarkerComponent _otherCMC = collision.gameObject.GetComponent<ColourMarkerComponent>();
        if(_myCMC != null && _otherCMC != null){
            if(_myCMC.Color == _otherCMC.Color){
                FixedJoint fj = this.gameObject.AddComponent<FixedJoint>();
                fj.connectedBody = _otherCMC.gameObject.GetComponent<Rigidbody>();

                if(_isTimerDestroyJoint){
                    Destroy(fj,_timeToDestroyJoint);
                }
            }
        }
    }
}
