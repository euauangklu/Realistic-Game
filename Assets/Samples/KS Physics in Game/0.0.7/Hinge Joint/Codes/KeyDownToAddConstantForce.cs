using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConstantForce))]
public class KeyDownToAddConstantForce : MonoBehaviour
{
    [SerializeField]
    KeyCode _key;
    public KeyCode Key { get => _key; set => _key = value; }

    ConstantForce _constantForceComponent;

    // Start is called before the first frame update
    void Start()
    {
        _constantForceComponent = this.GetComponent<ConstantForce>();
        _constantForceComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(_key)){
            _constantForceComponent.enabled = true;
        }else{
            _constantForceComponent.enabled = false;
        }
        
    }
}
