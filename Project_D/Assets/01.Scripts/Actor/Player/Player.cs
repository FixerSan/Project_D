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

    public bool CheckMove()
    {
        if (Managers.Input.joystickInputValue != Vector2.zero)
        {
            controller.ChangeState(Define.PlayerState.Move);
            return true;
        }
        return false;
    }

    public bool CheckStop()
    {
        if(Managers.Input.joystickInputValue == Vector2.zero)
        {
            controller.ChangeState(Define.PlayerState.Idle);
            Stop();
            return true;
        }
        return false;
    }

    public void Move(Vector2 _moveDir)
    {
        if (_moveDir.x > 0) controller.ChangeDirection(Define.Direction.Left);
        if (_moveDir.x < 0) controller.ChangeDirection(Define.Direction.Right);

        controller.rb.velocity = _moveDir * status.CurrentSpeed * 10 * Time.fixedDeltaTime;
    }

    public void Stop()
    {
        controller.rb.velocity = Vector2.zero;
    }
}

public class PlayerData
{

}
