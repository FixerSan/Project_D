using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class NPC
{
    public abstract void Interaction();
}

namespace NPCs 
{
    namespace TestNPC
    {
        public class Zero : NPC
        {
            public override void Interaction()
            {
                Managers.Dialog.Call(0);
            }
        }

        public class One : NPC
        {
            public override void Interaction()
            {
                Managers.UI.ShowPopupUI<UIPopup_Dungeon_Challenge>();
            }
        }
    }
}