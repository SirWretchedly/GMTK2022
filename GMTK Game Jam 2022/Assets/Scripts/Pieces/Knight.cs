using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Knight : Piece
{
    [SerializeField] private float jumpTime, speed;

    private void Update()
    {
        SetTarget();
        Animate();

        if (ready && GetComponent<AIDestinationSetter>().target != transform)
            Ability();

        if(ability)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if(transform.localScale == new Vector3(1.5f, 1.5f, 1.5f))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public override void Animate()
    {
        if (ability)
            GetComponent<Animator>().Play("idle");
        else
        {
            if(GetComponent<AIDestinationSetter>().target == transform)
            {
                GetComponent<Animator>().Play("idle");
            }
            else
                GetComponent<Animator>().Play("bounce");
        }
    }

    public override void Ability()
    {
        StartCoroutine(Cooldown());
        StartCoroutine(Jump());     
    }

    IEnumerator Jump()
    {
        ability = true;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(jumpTime);
        GetComponent<Collider2D>().enabled = true;
        ability = false;
    }
}
