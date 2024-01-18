using NPCs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPC npc;

    public void Init(NPC _npc)
    {
        npc = _npc;
    }

    public void Interaction()
    {
        npc.Interaction();
    }
}
