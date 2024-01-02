using System;

public class TestScene : BaseScene
{
    public override void Init(Action _callback)
    {
        Managers.UI.ShowSceneUI<UIScene_Main>();
        _callback?.Invoke();
    }

    public override void Clear()
    {

    }
}
