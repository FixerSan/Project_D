using UnityEngine.Rendering.Universal;

namespace PlayerStates
{
    public class Idle : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {

        }
        public override void Update(PlayerController _entity)
        {
            if (_entity.player.CheckMove()) return;
        }
        public override void Exit(PlayerController _entity)
        {

        }
    }
    public class Move : State<PlayerController>
    {
        public override void Enter(PlayerController _entity)
        {

        }
        public override void Update(PlayerController _entity)
        {
            if (_entity.player.CheckStop()) return;
            _entity.player.Move(Managers.Input.joystickInputValue);
        }
        public override void Exit(PlayerController _entity)
        {
            
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
