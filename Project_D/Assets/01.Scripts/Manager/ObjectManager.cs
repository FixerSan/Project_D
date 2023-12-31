using Monsters;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public PlayerController PlayerController { get { return playerController; } }
    private PlayerController playerController;

    public Transform PlayerControllerTrans
    {
        get
        {
            if (playerControllerTrans == null)
            {
                GameObject go = GameObject.Find("@PlayerControllerTrans");
                if (go == null)
                    go = new GameObject(name: "@PlayerControllerTrans");
                playerControllerTrans = go.transform;
            }
            return playerControllerTrans;
        }
    }
    public Transform playerControllerTrans;

    public List<MonsterController> monsters = new List<MonsterController>();

    public void SpawnPlayer(int _playerCharacterIndex, Vector3 _playerPos)
    {
        playerController = Managers.Resource.Instantiate($"PlayerCharacter_{_playerCharacterIndex}").GetOrAddComponent<PlayerController>();
        Player player = new Player(new PlayerData(), playerController, new Status());
        Dictionary<Define.PlayerState, State<PlayerController>> states = new Dictionary<Define.PlayerState, State<PlayerController>>();
        states.Add(Define.PlayerState.Idle, new PlayerStates.Idle());
        states.Add(Define.PlayerState.Move, new PlayerStates.Move());
        states.Add(Define.PlayerState.Attack, new PlayerStates.Attack());
        states.Add(Define.PlayerState.SkillCast, new PlayerStates.SkillCast());
        states.Add(Define.PlayerState.Die, new PlayerStates.Die());
        playerController.SetPosition(_playerPos);
        playerController.Init(player, states);
    }

    public void SpawnMonster(int _monsterIndex, Vector3 _monsterPos)
    {
        MonsterController controller = Managers.Resource.Instantiate($"Monster_{_monsterIndex}").GetOrAddComponent<MonsterController>();
        BaseMonster monster = null;
        Dictionary<Define.MonsterState, State<MonsterController>> states = new Dictionary<Define.MonsterState, State<MonsterController>>();

        switch (_monsterIndex)
        {
            case 0:
                monster = new BaseMonster(new MonsterData(), controller, new Status());
                states.Add(Define.MonsterState.Create, new MonsterStates.Base.Create());
                states.Add(Define.MonsterState.Idle, new MonsterStates.Base.Idle());
                states.Add(Define.MonsterState.Move, new MonsterStates.Base.Move());
                states.Add(Define.MonsterState.Follow, new MonsterStates.Base.Follow());
                states.Add(Define.MonsterState.Attack, new MonsterStates.Base.Attack());
                states.Add(Define.MonsterState.SkillCast, new MonsterStates.Base.SkillCast());
                states.Add(Define.MonsterState.Die, new MonsterStates.Base.Die());
                break;

            default:
                monster = new BaseMonster(new MonsterData(), controller, new Status());
                states.Add(Define.MonsterState.Create, new MonsterStates.Base.Create());
                states.Add(Define.MonsterState.Idle, new MonsterStates.Base.Create());
                states.Add(Define.MonsterState.Move, new MonsterStates.Base.Move());
                states.Add(Define.MonsterState.Follow, new MonsterStates.Base.Follow());
                states.Add(Define.MonsterState.Attack, new MonsterStates.Base.Attack());
                states.Add(Define.MonsterState.SkillCast, new MonsterStates.Base.SkillCast());
                states.Add(Define.MonsterState.Die, new MonsterStates.Base.Die());
                break;
        }
        controller.SetPosition(_monsterPos);
        controller.Init(monster, states);
        monsters.Add(controller);
    }

    public void ClearPlayer()
    {
        Managers.Resource.Destroy(playerController.gameObject);
        playerController = null;
    }

    public void ClearMonster(MonsterController _monster)
    {
        if (monsters.Contains(_monster))
        {
            monsters.Remove(_monster);
            Managers.Resource.Destroy(_monster.gameObject);
        }
    }

    public void ClearAllMonster()
    {
        for (int i = 0; i < monsters.Count; i++)
            Managers.Resource.Destroy(monsters[i].gameObject);

        monsters.Clear();
    }
}
