using UnityEngine;
using System.Collections;


public class Member
{
    public MonsterData data;
    public MemberController controller;

    public bool CheckMove()
    {
        if (Managers.Input.joystickInputValue != Vector2.zero)
        {
            controller.ChangeState(Define.MemberState.Move);
            return true;
        }
        return false;
    }

    public bool CheckStop()
    {
        if (Managers.Input.joystickInputValue == Vector2.zero)
        {
            controller.ChangeState(Define.MemberState.Idle);
            Stop();
            return true;
        }
        return false;
    }

    public void Move(Vector2 _moveDir)
    {
        if (_moveDir.x > 0) controller.ChangeDirection(Define.Direction.Left);
        if (_moveDir.x < 0) controller.ChangeDirection(Define.Direction.Right);

        controller.rb.velocity = _moveDir * controller.status.CurrentSpeed * 10 * Time.fixedDeltaTime;
    }

    public void Stop()
    {
        controller.rb.velocity = Vector2.zero;
    }
    public virtual bool CheckDie()
    {
        if (controller.status.currentNowHP <= 0.0)
        {
            controller.ChangeState(Define.MemberState.Die);
            return true;
        }

        return false;
    }

    public virtual void Die()
    {
        controller.isDead = true;
        controller.StopAllCoroutines();
        controller.StartCoroutine(DieRoutine());
    }

    public virtual IEnumerator DieRoutine()
    {
        yield return new WaitForSeconds(2);
        //Managers.Object.ClearMonster(controller);
    }
}

public class BaseMember : Member
{
    public BaseMember(MonsterData _data, MemberController _controller) 
    {
        data = _data;
        controller = _controller;
    }
}

public class MemberData
{
    public MemberData()
    {

    }
}
