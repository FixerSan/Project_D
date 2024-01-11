using UnityEngine;
using System.Collections;

public class Player
{
    public PlayerData data;
    public PlayerController controller;
    public Actor attackTarget;

    private Collider2D[] tempColliders;
    private Actor tempActorController;


    public Player(PlayerData _data, PlayerController _controller)
    {
        data = _data;
        controller = _controller;
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

        controller.rb.velocity = _moveDir * controller.status.CurrentSpeed * 10 * Time.fixedDeltaTime;
    }

    public void Stop()
    {
        controller.rb.velocity = Vector2.zero;
    }

    public void SetAttackTarget(Actor _attackTarget)
    {
        attackTarget = _attackTarget;
    }

    public virtual void FindAttackTarget()
    {
        controller.StartCoroutine(FindAttackTargetRoutine());
    }

    public virtual IEnumerator FindAttackTargetRoutine()
    {
        while (!controller.isDead)
        {
            //범위 안에 플레이어 캐릭터를 찾고
            tempColliders = Physics2D.OverlapCircleAll(controller.transform.position, data.findAttackTargetRange);

            for (int i = 0; i < tempColliders.Length; i++)
            {
                tempActorController = tempColliders[i].GetComponent<MonsterController>();
                if (tempActorController != null)
                {
                    if (attackTarget == null)
                    {
                        SetAttackTarget(tempActorController);
                        continue;
                    }

                    if (Vector2.Distance(tempActorController.transform.position, controller.transform.position) < Vector2.Distance(attackTarget.transform.position, controller.transform.position))
                        attackTarget = tempActorController;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    public virtual bool CheckAttack()
    {
        if (attackTarget == null) return false;
        if (Vector2.Distance(controller.transform.position, attackTarget.transform.position) < data.attackTargetRange)
        {
            controller.ChangeState(Define.PlayerState.Attack);
            return true;
        }

        return false;
    }

    public virtual void Attack()
    {
        controller.StartCoroutine(AttackRoutione());
    }

    public virtual IEnumerator AttackRoutione()
    {
        Managers.Battle.AttackCalculation(controller, attackTarget);
        yield return new WaitForSeconds(1f);
        controller.ChangeState(Define.PlayerState.Idle);
    }
    public virtual bool CheckDie()
    {
        if (controller.status.currentNowHP <= 0.0)
        {
            controller.ChangeState(Define.PlayerState.Die);
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

public class PlayerData
{
    public float findAttackTargetRange;
    public float attackTargetRange;
    public PlayerData()
    {
        findAttackTargetRange = 2.0f;
        attackTargetRange = 1.0f;
    }
}
