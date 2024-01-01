using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class Idle : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {
            Debug.Log("Idle 들어옴");
        }
        public override void Update(PlayerController _entity)
        {
            Debug.Log("Idle 업데이트");

        }
        public override void Exit(PlayerController _entity)
        {
            Debug.Log("Idle 나감");

        }
    }
    public class Move : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {
            Debug.Log("Move 들어옴");

        }
        public override void Update(PlayerController _entity)
        {
            Debug.Log("Move 업데이트");

        }
        public override void Exit(PlayerController _entity)
        {
            Debug.Log("Move 나감");

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
