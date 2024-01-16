using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup_Dungeon_Challenge : UIPopup
{
    private Transform slotTrans;
    private List<UISlot_DungeonSelect> slots = new List<UISlot_DungeonSelect>();

    public override bool Init()
    {
        if(!base.Init())    return false;
        BindButton(typeof(Buttons));
        slotTrans = Util.FindChild<Transform>(gameObject, "SlotTrans", true);

        BindEvent(GetButton((int)Buttons.Button_Close).gameObject, () => { ClosePopupUP(); Managers.Game.dungeon.currentDungeonData = null; });
        DrawUI();
        return true;
    }

    public void DrawUI()
    {
        CreateSlots();
    }

    public void CreateSlots()
    {
        foreach (var dungeonData in Managers.Data.dungeonDatas)
        {
            UISlot_DungeonSelect slot = Managers.Resource.Instantiate("UISlot_DungeonSelect").GetOrAddComponent<UISlot_DungeonSelect>();
            slot.transform.SetParent(slotTrans);
            slot.DrawUI(dungeonData.Value.index);
            slots.Add(slot);
        }
    }

    private enum Buttons
    {
        Button_Close
    }
}
