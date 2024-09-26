using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CraneController : MonoBehaviour
{
    [SerializeField] protected ConfigurableJoint craneMovingPartJoint;

    
    
    [SerializeField] protected Slider sliderX;
    [SerializeField] protected Slider sliderY;
    [SerializeField] protected Slider sliderZ;
    
    private Vector3 targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        sliderX.onValueChanged.AddListener(SliderXChange);
        sliderY.onValueChanged.AddListener(SliderYChange);
        sliderZ.onValueChanged.AddListener(SliderZChange);

        targetPosition = craneMovingPartJoint.targetPosition;
    }
    
    void SliderXChange(float val)
    {
        targetPosition.x = val;
        craneMovingPartJoint.targetPosition = targetPosition;
    }
    void SliderYChange(float val)
    {
        targetPosition.y = val;
        craneMovingPartJoint.targetPosition = targetPosition;
    }
    void SliderZChange(float val)
    {
        targetPosition.z = val;
        craneMovingPartJoint.targetPosition = targetPosition;
    }
}
