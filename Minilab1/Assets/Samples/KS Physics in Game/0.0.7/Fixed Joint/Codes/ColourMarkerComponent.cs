using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourMarkerComponent : MonoBehaviour
{
    public enum ColourMark{
        RED,
        GREEN,
        BLUE
    };

    [SerializeField]
    private ColourMark color;

    public ColourMark Color { get => color; set => color = value; }
}
