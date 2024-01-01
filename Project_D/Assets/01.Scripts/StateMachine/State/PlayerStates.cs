using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class Idle : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {
            Debug.Log("Idle ����");
        }
        public override void Update(PlayerController _entity)
        {
            Debug.Log("Idle ������Ʈ");

        }
        public override void Exit(PlayerController _entity)
        {
            Debug.Log("Idle ����");

        }
    }
    public class Move : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {
            Debug.Log("Move ����");

        }
        public override void Update(PlayerController _entity)
        {
            Debug.Log("Move ������Ʈ");

        }
        public override void Exit(PlayerController _entity)
        {
            Debug.Log("Move ����");

        }
    }
    public class Attack : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {

        }
        public override void Update(PlayerController _entity)
        {

        }
        public override void Exit(PlayerController _entity)
        {

        }
    }
    public class SkillCast : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {

        }
        public override void Update(PlayerController _entity)
        {

        }
        public override void Exit(PlayerController _entity)
        {

        }
    }
    public class Die : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {

        }
        public override void Update(PlayerController _entity)
        {

        }
        public override void Exit(PlayerController _entity)
        {

        }
    }
}
