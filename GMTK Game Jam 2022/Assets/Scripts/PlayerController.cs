using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DetectBlock[] detectBlocks;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        detectBlocks = GetComponentsInChildren<DetectBlock>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown("w") && !detectBlocks[0].isBlocked)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            sprite.flipY = false;
            animator.Play("die-roll");

        }
        else if(Input.GetKeyDown("s") && !detectBlocks[2].isBlocked)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            sprite.flipY = true;
            animator.Play("die-roll");
        }
        else if(Input.GetKeyDown("d") && !detectBlocks[1].isBlocked)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            sprite.flipX = true;
            animator.Play("die-roll-side");
        }
        else if(Input.GetKeyDown("a") && !detectBlocks[3].isBlocked)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            sprite.flipX = false;
            animator.Play("die-roll-side");
        }
    }
}
