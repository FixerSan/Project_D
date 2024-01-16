using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UISlot_DungeonSelect : UIBase
{
    public DungeonData data;

    public override bool Init()
    {
        if (!base.Init()) return false;
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindObject(typeof(Objects));

        BindEvent(GetButton((int)Buttons.Button_Select_NoCleared).gameObject, OnClick_NoClearedButton);
        BindEvent(GetButton((int)Buttons.Button_Select_Cleared).gameObject, OnClick_ClearedButton);
        return true;
    }

    public void DrawUI(int _index)
    {
        data = Managers.Data.GetDungeonData(_index);
        GetObject((int)Objects.Bundle_CantChallenge).SetActive(false);
        GetObject((int)Objects.Bundle_Cleared).SetActive(false);
        GetObject((int)Objects.Bundle_NoCleared).SetActive(false);

        GetText((int)Texts.Text_DungeonTitleText).text = data.name;
        GetText((int)Texts.Text_Description).text = data.description;

        if ((int)Managers.Game.userData.tier < (int)data.tier)
        {
            GetObject((int)Objects.Bundle_CantChallenge).SetActive(true);
            return;
        }

        if (Managers.Game.dungeon.CheckCleard(data.index))
        {
            GetObject((int)Objects.Bundle_Cleared).SetActive(true);
            return;
        }

        GetObject((int)Objects.Bundle_NoCleared).SetActive(true);
    }

    public void OnClick_NoClearedButton()
    {
        Managers.Game.dungeon.SelectDungeon(data.index);
    }

    public void OnClick_ClearedButton()
    {
        Managers.Game.dungeon.SelectCleardDungeon(data.index);
    }

    private enum Texts
    {
        Text_DungeonTitleText,
        Text_Description
    }

    private enum Objects
    {
        Bundle_NoCleared,
        Bundle_Cleared,
        Bundle_CantChallenge
    }

    private enum Buttons
    {
        Button_Select_NoCleared,
        Button_Select_Cleared,
    }
}
