using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyEventSettings
{
    public KeyCode KeycodeToActivate;
    public TypeOfKeyEvent TypeOfKeyEventToCapture = TypeOfKeyEvent.KEYDOWN;
}
