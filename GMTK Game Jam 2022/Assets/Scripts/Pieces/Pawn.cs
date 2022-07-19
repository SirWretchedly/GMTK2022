using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Pawn : Piece
{
    private void Update()
    {
        SetTarget();
        Animate();
    }

    public override void Animate()
    {
        if (GetComponent<AIDestinationSetter>().target == transform)
        {
            GetComponent<Animator>().Play("idle");
        }
        else
            GetComponent<Animator>().Play("bounce");
    }

    public override void Ability() { }
}
