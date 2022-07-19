using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class King : Piece
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private void Update()
    {
        SetTarget();
        Animate();

        if (GetComponent<AIDestinationSetter>().target != transform)
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
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
