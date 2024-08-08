using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TorqueSettings
{
    public bool IsGlobal = true;
    public Vector3 TorqueAxis;
    public float AmountOfTorque = 100;
    public ForceMode ForceMode = ForceMode.Impulse;
}
