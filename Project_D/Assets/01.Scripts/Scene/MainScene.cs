using System;
using UnityEngine;

public class MainScene : BaseScene
{
    public override void Init(Action _callback)
    {
        Managers.UI.ShowSceneUI<UIScene_Main>();
        Managers.Object.SpawnPlayer(0, Vector3.zero);
        Managers.Object.SpawnMonster(0, new Vector3(0, 3, 0));
        _callback?.Invoke();
    }
    public override void Clear()
    {

    }

}
