using Monsters;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public PlayerController PlayerController { get { return playerController; } }
    private PlayerController playerController;

    public Vector3 PlayerMovePos 
    {
        get
        {
            if(playerMovePos == null)
                CreatePlayerMovePos();
            return playerMovePos.transform.position; 
        }
    }
    private PlayerMovePos playerMovePos;


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
    public List<MemberController> members = new List<MemberController>();
    public List<NPCController> npcs = new List<NPCController>();

    public PlayerController SpawnPlayer(int _playerCharacterIndex, Vector3 _playerPos)
    {
        playerController = Managers.Resource.Instantiate($"PlayerCharacter_{_playerCharacterIndex}").GetOrAddComponent<PlayerController>();
        Player player = new Player(new PlayerData(), playerController);
        Dictionary<Define.PlayerState, State<PlayerController>> states = new Dictionary<Define.PlayerState, State<PlayerController>>();
        states.Add(Define.PlayerState.Idle, new PlayerStates.Idle());
        states.Add(Define.PlayerState.Move, new PlayerStates.Move());
        states.Add(Define.PlayerState.Follow, new PlayerStates.Follow());
        states.Add(Define.PlayerState.Attack, new PlayerStates.Attack());
        states.Add(Define.PlayerState.SkillCast, new PlayerStates.SkillCast());
        states.Add(Define.PlayerState.Die, new PlayerStates.Die());
        playerController.SetPosition(_playerPos);
        playerController.Init(player, states, new Status());

        return playerController;
    }

    public MemberController SpawnMember(int _memberIndex, Vector3 _memberPos)
    {
        MemberController controller = Managers.Resource.Instantiate($"Member_{_memberIndex}").GetOrAddComponent<MemberController>();
        Member member = null;
        Dictionary<Define.MemberState, State<MemberController>> states = new Dictionary<Define.MemberState, State<MemberController>>();

        switch(_memberIndex)
        {
            case 0:
                member = new BaseMember(new MonsterData(), controller);
                states.Add(Define.MemberState.Idle, new MemberStates.Base.Idle());
                states.Add(Define.MemberState.Move, new MemberStates.Base.Move());
                states.Add(Define.MemberState.Attack, new MemberStates.Base.Attack());
                states.Add(Define.MemberState.SkillCast, new MemberStates.Base.SkillCast());
                states.Add(Define.MemberState.Die, new MemberStates.Base.Die());
                break;

            default:
                member = new BaseMember(new MonsterData(), controller);
                states.Add(Define.MemberState.Idle, new MemberStates.Base.Idle());
                states.Add(Define.MemberState.Move, new MemberStates.Base.Move());
                states.Add(Define.MemberState.Attack, new MemberStates.Base.Attack());
                states.Add(Define.MemberState.SkillCast, new MemberStates.Base.SkillCast());
                states.Add(Define.MemberState.Die, new MemberStates.Base.Die());
                break;
        }

        controller.SetPosition(_memberPos);
        controller.Init(member, states, new Status());
        members.Add(controller);

        return controller;
    }

    public MonsterController SpawnMonster(int _monsterIndex, Vector3 _monsterPos)
    {
        MonsterController controller = Managers.Resource.Instantiate($"Monster_{_monsterIndex}").GetOrAddComponent<MonsterController>();
        BaseMonster monster = null;
        Dictionary<Define.MonsterState, State<MonsterController>> states = new Dictionary<Define.MonsterState, State<MonsterController>>();

        switch (_monsterIndex)
        {
            case 0:
                monster = new BaseMonster(new MonsterData(), controller);
                states.Add(Define.MonsterState.Create, new MonsterStates.Base.Create());
                states.Add(Define.MonsterState.Idle, new MonsterStates.Base.Idle());
                states.Add(Define.MonsterState.Move, new MonsterStates.Base.Move());
                states.Add(Define.MonsterState.Follow, new MonsterStates.Base.Follow());
                states.Add(Define.MonsterState.Attack, new MonsterStates.Base.Attack());
                states.Add(Define.MonsterState.SkillCast, new MonsterStates.Base.SkillCast());
                states.Add(Define.MonsterState.Die, new MonsterStates.Base.Die());
                break;

            default:
                monster = new BaseMonster(new MonsterData(), controller);
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
        controller.Init(monster, states,new Status());
        monsters.Add(controller);

        return controller;
    }

    public void SpawnNPC(int _npcIndex, Vector3 _npcPos)
    {
        NPCController controller = Managers.Resource.Instantiate($"NPC_{_npcIndex}").GetOrAddComponent<NPCController>();
        controller.transform.position = _npcPos;

        switch (_npcIndex)
        {
            case 0:
                controller.Init(new NPCs.TestNPC.Zero());
                break;
            case 1:
                controller.Init(new NPCs.TestNPC.One());
                break;
        }

        npcs.Add(controller);
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

    public void CreatePlayerMovePos()
    {
        GameObject go = GameObject.Find("PlayerMovePos");
        if(go == null)
            go = Managers.Resource.Instantiate("PlayerMovePos");
        playerMovePos = go.GetOrAddComponent<PlayerMovePos>();
    }
}
