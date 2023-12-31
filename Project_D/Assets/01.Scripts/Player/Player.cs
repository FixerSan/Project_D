using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public PlayerData data;
    public PlayerController controller;
    public Status status;

    public Player(PlayerData _data, PlayerController _controller, Status _status)
    {
        data = _data;
        controller = _controller;
        status = _status;
    }

    public void CheckMove()
    {
        if(Managers.Input.joystickInputValue != Vector2.zero)
        {
            Move(Managers.Input.joystickInputValue * status.CurrentSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector2 _moveValue)
    {
        controller.rb.velocity = _moveValue;
    }

    public void Stop()
    {
        controller.rb.velocity = Vector2.zero;
    }
}

public class PlayerData
{

}
