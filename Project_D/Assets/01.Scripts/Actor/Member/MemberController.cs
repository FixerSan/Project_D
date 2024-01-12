using static UnityEditor.VersionControl.Asset;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Collections;

public class MemberController : Actor
{
    public Member member;
    private StateMachine<MemberController> fsm;
    private Dictionary<Define.MemberState, State<MemberController>> states;
    public Dictionary<Define.MemberState, int> animationHashs = new Dictionary<Define.MemberState, int>();

    public Define.MemberState currentState;
    public Define.MemberState changeState;
    public Rigidbody2D rb;
    public Animator anim;

    private bool init = false;
    public bool isDead = false;
    public void Init(Member _member, Dictionary<Define.MemberState, State<MemberController>> _states, Status _status)
    {
        member = _member;
        states = _states;
        status = _status;

        fsm = new StateMachine<MemberController>(this, states[Define.MemberState.Idle]);
        rb = gameObject.GetOrAddComponent<Rigidbody2D>();

        animationHashs.Clear();
        animationHashs.Add(Define.MemberState.Idle, Animator.StringToHash("0_idle"));
        animationHashs.Add(Define.MemberState.Move, Animator.StringToHash("1_Run"));
        animationHashs.Add(Define.MemberState.Attack, Animator.StringToHash("2_Attack_Normal"));
        animationHashs.Add(Define.MemberState.Die, Animator.StringToHash("4_Death")); 
        anim = Util.FindChild<Animator>(gameObject, "Sprite", true);

        init = true;
    }

    public void Update()
    {
        if (!init) return;
        if (isDead) return;
        if (member.CheckDie())
            return;
        fsm.Update();
        CheckChangeStateInIspector();
    }

    public void ChangeState(Define.MemberState _nextState, bool _isCanChangeSameState = false)
    {
        if (currentState == _nextState)
        {
            if (_isCanChangeSameState)
                fsm.ChangeState(states[_nextState]);
            return;
        }
        currentState = _nextState;
        changeState = _nextState;
        anim.Play(animationHashs[_nextState]);
        fsm.ChangeState(states[_nextState]);
    }

    public void CheckChangeStateInIspector()
    {
        if (currentState != changeState)
            ChangeState(changeState);
    }

    public override void Hit(float _damage)
    {
        GetDamage(_damage);
    }

    public override void GetDamage(float _damage)
    {
        status.currentNowHP -= _damage;
    }
}
