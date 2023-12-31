using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    public PlayerController controller;

    public void SpawnPlayer()
    {
        controller = Managers.Resource.Instantiate("Player").GetOrAddComponent<PlayerController>();
        controller.player = new Player(new PlayerData(), controller, new Status());
        controller.Init();
    }
}
