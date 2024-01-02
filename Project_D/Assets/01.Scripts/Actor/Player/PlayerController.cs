using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    public Player player;
    private StateMachine<PlayerController> fsm;
    private Dictionary<Define.PlayerState, State<PlayerController>> states;
    private Define.PlayerState currentState;
    private Dictionary<IEnumerator, Coroutine> routines = new Dictionary<IEnumerator, Coroutine>();

    public Define.PlayerState changeState;
    public Rigidbody2D rb;

    private bool init = false;

    public void Init(Player _player, Dictionary<Define.PlayerState, State<PlayerController>> _states)
    {
        player = _player;
        states = _states;

        fsm = new StateMachine<PlayerController>(this, states[Define.PlayerState.Idle]);
        rb = gameObject.GetOrAddComponent<Rigidbody2D>();
        init = true;
    }

    public void Update()
    {
        if (!init) return;
        player.CheckMove();
        fsm.Update();
        CheckChangeStateInIspector();
    }

    public void ChangeState(Define.PlayerState _nextState, bool _isCanChangeSameState = false)
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

    public new void StartCoroutine(IEnumerator _routine)
    {
        routines.Add(_routine, base.StartCoroutine(_routine));
    }

    public new void StopCoroutine(IEnumerator _routine)
    {
        base.StopCoroutine(routines[_routine]);
        routines.Remove(_routine);
    }
}
