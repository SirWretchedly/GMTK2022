using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bishop : Piece
{
    [SerializeField] private ParticleSystem particles;

    private void Update()
    {
        SetTarget();
        Animate();

        if (ready && GetComponent<AIDestinationSetter>().target != transform)
            Ability();
    }

    public override void Animate()
    {
        if (GetComponent<AIPath>().reachedDestination)
            GetComponent<Animator>().Play("idle");
        else if (GetComponent<AIDestinationSetter>().target == transform)
        {
            GetComponent<Animator>().Play("idle");
        }
        else
            GetComponent<Animator>().Play("bounce");
    }

    public override void Ability()
    {
        particles.Play();
        StartCoroutine(Cooldown());
    }
}
