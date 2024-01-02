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

    public void CheckPlayerMove()
    {
        if (player == null) return;
        if (joystickInput != Vector2.zero)
            PlayerMove();
    }

    public void PlayerMove()
    {
        player.controller.rb.velocity = joystickInput * player.status.CurrentSpeed * Time.fixedDeltaTime;
    }
}
