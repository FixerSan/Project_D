using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemberStates
{
    namespace Base
    {
        public class Idle : State<MemberController>
        {
            public override void Enter(MemberController _entity)
            {

            }
            public override void Update(MemberController _entity)
            {
                if (_entity.member.CheckMove()) return;
            }
            public override void Exit(MemberController _entity)
            {

            }
        }
        public class Move : State<MemberController>
        {
            public override void Enter(MemberController _entity)
            {

            }
            public override void Update(MemberController _entity)
            {
                if (_entity.member.CheckStop()) return;
                _entity.member.Move(Managers.Object.PlayerMovePos - _entity.transform.position);
            }
            public override void Exit(MemberController _entity)
            {

            }
        }
        public class Attack : State<MemberController>
        {
            public override void Enter(MemberController _entity)
            {

            }
            public override void Update(MemberController _entity)
            {

            }
            public override void Exit(MemberController _entity)
            {

            }
        }
        public class SkillCast : State<MemberController>
        {
            public override void Enter(MemberController _entity)
            {

            }
            public override void Update(MemberController _entity)
            {

            }
            public override void Exit(MemberController _entity)
            {

            }
        }
        public class Die : State<MemberController>
        {
            public override void Enter(MemberController _entity)
            {
                _entity.member.Die();
            }
            public override void Update(MemberController _entity)
            {

            }
            public override void Exit(MemberController _entity)
            {

            }
        }


    }
}
