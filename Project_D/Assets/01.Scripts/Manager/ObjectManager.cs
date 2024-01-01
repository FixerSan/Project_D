using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    public PlayerController Controller { get { return controller; } }
    private PlayerController controller;


    public void SpawnPlayer(int _playerCharacterIndex, Vector3 _playerPos)
    {
        Player player = new Player(new PlayerData(), controller, new Status());
        Dictionary<Define.PlayerState, State<PlayerController>> states = new Dictionary<Define.PlayerState, State<PlayerController>>();
        states.Add(Define.PlayerState.Idle, new PlayerStates.Idle());
        states.Add(Define.PlayerState.Move, new PlayerStates.Move());
        states.Add(Define.PlayerState.Attack, new PlayerStates.Attack());
        states.Add(Define.PlayerState.SkillCast, new PlayerStates.SkillCast());
        states.Add(Define.PlayerState.Die, new PlayerStates.Die());
        switch (_playerCharacterIndex)
        {
            case 0:
                controller = Managers.Resource.Instantiate("Player").GetOrAddComponent<PlayerController>();
                break;

            default:
                controller = Managers.Resource.Instantiate("Player").GetOrAddComponent<PlayerController>();
                break;
        }

        controller.SetPosition(_playerPos);
        controller.Init(player, states);
    }
}
