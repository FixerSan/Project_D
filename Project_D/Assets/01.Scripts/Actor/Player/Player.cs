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
        if (Managers.Input.joystickInputValue != Vector2.zero)
        {
            Move(Managers.Input.joystickInputValue);
            return;
        }

        Stop();
    }

    public void Move(Vector2 _moveDir)
    {
        controller.rb.velocity = _moveDir * status.CurrentSpeed * Time.fixedDeltaTime;
    }

    public void Stop()
    {
        controller.rb.velocity = Vector2.zero;
    }
}

public class PlayerData
{

}
