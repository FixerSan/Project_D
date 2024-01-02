using System.Collections;
using UnityEngine;

public class Monster
{
    public MonsterData data;
    public MonsterController controller;
    public Status status;

    public Actor attackTarget;

    private Vector3 dir;
    #region Temp
    private Collider2D[] tempColliders;
    private Actor tempActor;
    #endregion

    public void Created()
    {
        controller.StartCoroutine(CreatedRoutine());
    }

    public IEnumerator CreatedRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        FindAttackTarget();
        controller.ChangeState(Define.MonsterState.Idle);
    }

    public void CheckMove()
    {

    }

    public void Move(Vector2 _moveDir)
    {
        controller.rb.velocity = _moveDir * status.CurrentSpeed * Time.fixedDeltaTime;
    }

    public void Stop()
    {
        controller.rb.velocity = Vector2.zero;
    }

    public void SetAttackTarget(PlayerController _attackTarget)
    {
        attackTarget = _attackTarget;
    }

    public virtual bool CheckFollow()
    {
        if (attackTarget != null)
        {
            controller.ChangeState(Define.MonsterState.Follow);
            return true;
        }
        return false;
    }

    public virtual void Follow()
    {
        if (attackTarget == null)
        {
            controller.ChangeState(Define.MonsterState.Idle);
            return;
        }

        dir = (attackTarget.transform.position - controller.transform.position).normalized;
        Move(dir);
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

            //플레이어 캐릭터 먼저 찾기
            for (int i = 0; i < tempColliders.Length; i++)
            {
                tempActor = tempColliders[i].GetComponent<PlayerController>();
                if (tempActor != null)
                {
                    attackTarget = tempActor;
                    break;
                }
            }


            for (int i = 0; i < tempColliders.Length; i++)
            {
                tempActor = tempColliders[i].GetComponent<MenberController>();
                if (tempActor != null)
                {
                    if (attackTarget == null)
                    {
                        attackTarget = tempActor;
                        continue;
                    }

                    if (Vector2.Distance(tempActor.transform.position, controller.transform.position) < Vector2.Distance(attackTarget.transform.position, controller.transform.position))
                        attackTarget = tempActor;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

namespace Monsters
{
    public class BaseMonster : Monster
    {
        public BaseMonster(MonsterData _data, MonsterController _controller, Status _status)
        {
            data = _data;
            controller = _controller;
            status = _status;
        }
    }
}

public class MonsterData
{
    public float findAttackTargetRange;
    public MonsterData()
    {
        findAttackTargetRange = 2.0f;
    }
}

