using System;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    public override void Init(Action _callback)
    {
        Managers.UI.ShowSceneUI<UIScene_Main>();
        Managers.Screen.CameraController.SetTarget(Managers.Object.SpawnPlayer(0, Vector3.zero).transform);
        Managers.Object.SpawnMonster(0, new Vector3(0, 3, 0));
        Managers.Object.SpawnMember(0, new Vector3(1, 1, 0));
        Managers.Object.SpawnNPC(0, new Vector3(-1, -1, 0));
        Managers.Object.SpawnNPC(1, new Vector3(1, -1, 0));

        _callback?.Invoke();
    }

    public override void Clear()
    {

    }
}
