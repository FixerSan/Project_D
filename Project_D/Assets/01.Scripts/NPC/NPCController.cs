using NPCs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPC npc;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        npc = new NPCs.TestNPC.Two();
    }

    public void Interaction()
    {
        npc.Interaction();
    }
}
