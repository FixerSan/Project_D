using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    public override void Init(Action _callback)
    {
        Managers.UI.ShowSceneUI<UIScene_Main>();
        Managers.Object.SpawnPlayer();
        _callback?.Invoke();
    }
    public override void Clear()
    {

    }

}
