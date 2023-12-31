using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    public Player player;
    public Rigidbody2D rb;

    private bool init = false;
    public override void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        init = true;
    }

    public void Update()
    {
        if (!init) return;
        player.CheckMove();
    }
}
