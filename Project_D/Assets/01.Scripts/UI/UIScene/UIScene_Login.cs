using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_Login : UIScene
{
    public override bool Init()
    {
        if(!base.Init()) return false;
        BindImage(typeof(Images));
        BindEvent(GetImage((int)Images.Image_Background).gameObject, Managers.Game.Login);

        return true;
    }

    private enum Images
    {
        Image_Background
    }
}
