using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup_Dungeon_Challenge_Select : UIPopup
{
    public override bool Init()
    {
        if(!base.Init()) return false;
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));
        BindEvent(GetButton((int)Buttons.Button_Start).gameObject, OnClick);
        BindEvent(GetButton((int)Buttons.Button_Close).gameObject, ClosePopupUP);
        return true;
    }

    public void DrawUI()
    {
        //Managers.Resource.Load<Sprite>(Managers.Game.dungeon.currentDungeonData.name, (_sprite) => { GetImage((int)Images.Image_Dungeon).sprite = _sprite;}); 
    }

    public void OnClick()
    {
        Managers.Game.dungeon.StartDungeon();
    }

    private enum Images
    {
        Image_Dungeon
    }

    private enum Buttons
    {
        Button_Start, Button_Close
    }
}
