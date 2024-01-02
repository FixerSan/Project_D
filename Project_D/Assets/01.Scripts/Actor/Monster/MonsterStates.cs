using UnityEngine;

namespace MonsterStates
{
    namespace Base
    {
        public class Create : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {
                Debug.Log("아니 이게 왜 두번 울려?");
                _entity.monster.Created();
            }
            public override void Update(MonsterController _entity)
            {

            }
            public override void Exit(MonsterController _entity)
            {

            }
        }

        public class Idle : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {

            }
            public override void Update(MonsterController _entity)
            {
                if (_entity.monster.CheckFollow()) return;
            }
            public override void Exit(MonsterController _entity)
            {

            }
        }

        public class Move : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {

            }
            public override void Update(MonsterController _entity)
            {
                if (_entity.monster.CheckFollow()) return;
            }
            public override void Exit(MonsterController _entity)
            {

            }
        }

        public class Follow : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {

            }
            public override void Update(MonsterController _entity)
            {
                _entity.monster.Follow();
            }
            public override void Exit(MonsterController _entity)
            {

            }
        }
        public class Attack : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {

            }
            public override void Update(MonsterController _entity)
            {

            }
            public override void Exit(MonsterController _entity)
            {

            }
        }
        public class SkillCast : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {

            }
            public override void Update(MonsterController _entity)
            {

            }
            public override void Exit(MonsterController _entity)
            {

            }
        }
        public class Die : State<MonsterController>
        {
            public override void Enter(MonsterController _entity)
            {

            }
            public override void Update(MonsterController _entity)
            {

            }
            public override void Exit(MonsterController _entity)
            {

            }
        }

    }
}
