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
    public class TestNPC : NPC
    {
        public override void Interaction()
        {
            Debug.Log("dsds");
        }
    }
}