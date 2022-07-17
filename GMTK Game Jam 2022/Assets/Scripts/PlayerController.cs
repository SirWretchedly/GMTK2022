using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DetectBlock[] detectBlocks;
    private Animator animator;
    private SpriteRenderer sprite;
    public Vector2 target;
    private bool ready = true;

    private void Start()
    {
        detectBlocks = GetComponentsInChildren<DetectBlock>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        target = transform.position;
    }

    void Update()
    {
        if(ready)
        {
            if (Input.GetKeyDown("w") && !detectBlocks[0].isBlocked)
            {
                target = new Vector2(transform.position.x, transform.position.y + 1);
                sprite.flipY = false;
                animator.Play("die-roll");
                StartCoroutine(Delay());

            }
            else if (Input.GetKeyDown("s") && !detectBlocks[2].isBlocked)
            {
                target = new Vector2(transform.position.x, transform.position.y - 1);
                sprite.flipY = true;
                animator.Play("die-roll");
                StartCoroutine(Delay());
            }
            else if (Input.GetKeyDown("d") && !detectBlocks[1].isBlocked)
            {
                target = new Vector2(transform.position.x + 1, transform.position.y);
                sprite.flipX = true;
                animator.Play("die-roll-side");
                StartCoroutine(Delay());
            }
            else if (Input.GetKeyDown("a") && !detectBlocks[3].isBlocked)
            {
                target = new Vector2(transform.position.x - 1, transform.position.y);
                sprite.flipX = false;
                animator.Play("die-roll-side");
                StartCoroutine(Delay());
            }
            else if (Vector2.Distance(transform.position, target) <= 0)
                target = transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 6);
    }

    IEnumerator Delay()
    {
        ready = false;
        yield return new WaitForSeconds(0.2f);
        ready = true;
    }
}
