using System;

public class LoginScene : BaseScene
{
    public override void Init(Action _callback)
    {
        Managers.UI.ShowSceneUI<UIScene_Login>();
        _callback?.Invoke();
    }
    public override void Clear()
    {

    }
}
