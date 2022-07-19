using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Vector3 target;
    [SerializeField] private float speed;
    [SerializeField] private DetectBlock[] blocks;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Start()
    {
        target = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(transform.position == target)
        {
            if(Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("a") && !blocks[0].isBlocked)
            {
                animator.Play("die-roll");
                sprite.flipY = false;
                target.y += 1;
            }
            if (!Input.GetKey("w") && Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("a") && !blocks[2].isBlocked)
            {
                animator.Play("die-roll");
                sprite.flipY = true;
                target.y -= 1;
            }
            if (!Input.GetKey("w") && !Input.GetKey("s") && Input.GetKey("d") && !Input.GetKey("a") && !blocks[1].isBlocked)
            {
                animator.Play("die-roll-side");
                sprite.flipX = true;
                target.x += 1;
            }
            if (!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("d") && Input.GetKey("a") && !blocks[3].isBlocked)
            {
                animator.Play("die-roll-side");
                sprite.flipX = false;
                target.x -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
