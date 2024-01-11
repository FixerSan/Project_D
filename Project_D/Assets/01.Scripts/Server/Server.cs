using System;
using UnityEngine;

public class Server : Singleton<Server>
{
    public IngameSystem ingame;

    public void Login(Action _callback)
    {
        ingame = new IngameSystem();
        _callback();
    }

    public void InputJoystick(Vector2 _joystickInput)
    {
        ingame.joystickInput = _joystickInput;
    }

    public void Update()
    {
        ingame.Update();
    }
}

public class IngameSystem
{
    public Vector2 joystickInput;
    public Player player;

    public void Update()
    {

    }
}
