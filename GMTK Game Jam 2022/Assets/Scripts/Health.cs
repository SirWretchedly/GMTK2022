using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 6;

    private Animator animator;

    private bool dead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            TakeDamage(1);
        if (Input.GetKeyDown("i"))
            Heal(1);
    }

    public void TakeDamage(float damage)
    {
        animator.ResetTrigger("damage");
        animator.SetTrigger("damage");
        health -= damage;
        if (health <= 0)
            dead = true;
    }

    public void Heal(float heal)
    {
        animator.ResetTrigger("heal");
        animator.SetTrigger("heal");
        health += heal;
        if (health > 6)
            health = 6;
    }
}
