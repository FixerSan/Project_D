using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class InputManager 
{
    public Vector2 joystickInputValue;
    public void InputJoystick(Vector2 _joystickInputValue)
    {
        joystickInputValue = _joystickInputValue;
    }
}
