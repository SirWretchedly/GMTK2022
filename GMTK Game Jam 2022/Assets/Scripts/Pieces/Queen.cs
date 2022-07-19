using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Queen : Piece
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Transform target;
    [SerializeField] private float dashTime, speed, fireCooldown;
    private bool fireReady = true;

    private void Update()
    {
        SetTarget();
        Animate();

        if (ready && GetComponent<AIDestinationSetter>().target != transform)
            Ability();

        if(fireReady && GetComponent<AIDestinationSetter>().target != transform)
        {
            particles.Play();
            StartCoroutine(FireCooldown());
        }

        if (ability)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
    }

    public override void Animate()
    {
        if (ability)
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
        StartCoroutine(Dash());
        StartCoroutine(Cooldown());
    }

    IEnumerator Dash()
    {
        ability = true;
        target.GetComponentInParent<RotateToTarget>().enabled = false;
        yield return new WaitForSeconds(dashTime);
        target.GetComponentInParent<RotateToTarget>().enabled = true;
        ability = false;
    }

    IEnumerator FireCooldown()
    {
        fireReady = false;
        yield return new WaitForSeconds(fireCooldown);
        fireReady = true;
    }
}
