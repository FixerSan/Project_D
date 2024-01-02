using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : Actor
{
    public Monster monster;
    private StateMachine<MonsterController> fsm;
    private Dictionary<Define.MonsterState, State<MonsterController>> states;
    private Define.MonsterState currentState;
    private Dictionary<IEnumerator, Coroutine> routines = new Dictionary<IEnumerator, Coroutine>();

    public Define.MonsterState changeState;
    public Rigidbody2D rb;

    private bool init = false;
    public bool isDead = false;

    public void Init(Monster _monster, Dictionary<Define.MonsterState, State<MonsterController>> _states)
    {
        monster = _monster;
        states = _states;

        fsm = new StateMachine<MonsterController>(this, states[Define.MonsterState.Create]);
        rb = gameObject.GetOrAddComponent<Rigidbody2D>();

        init = true;
        isDead = false;
    }


    public void ChangeState(Define.MonsterState _nextState, bool _isCanChangeSameState = false)
    {
        if (currentState == _nextState)
        {
            if (_isCanChangeSameState)
                fsm.ChangeState(states[_nextState]);
            return;
        }
        currentState = _nextState;
        changeState = _nextState;
        fsm.ChangeState(states[_nextState]);
    }

    public void CheckChangeStateInIspector()
    {
        if (currentState != changeState)
            ChangeState(changeState);
    }

    public void SetAttackTarget(PlayerController _attackTarget)
    {
        monster.SetAttackTarget(_attackTarget);
    }

    public new void StartCoroutine(IEnumerator _routine)
    {
        routines.Add(_routine, base.StartCoroutine(_routine));
    }

    public new void StopCoroutine(IEnumerator _routine)
    {
        base.StopCoroutine(routines[_routine]);
        routines.Remove(_routine);
    }

    public void Update()
    {
        if (!init) return;
        monster.CheckMove();
        CheckChangeStateInIspector();
        fsm.Update();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, monster.data.findAttackTargetRange);
    }
}
