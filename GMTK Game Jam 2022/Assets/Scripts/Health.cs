using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 6;

    private Animator animator;

    private bool dead = false;

    public Vector2 checkPointPos;

    private void Start()
    {
        animator = GameObject.Find("Health").GetComponent<Animator>();
        checkPointPos = new Vector2(1.5f, -2.5f);
    }

    private void UseCheckpoint() {
        transform.position = checkPointPos;
        GetComponent<PlayerController>().target = checkPointPos;
        dead = false;
        health = 6;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(ToggleTrueAndFalse(0.01f, "damage"));
        }

        if (Input.GetKeyDown("i"))
        {
            StartCoroutine(ToggleTrueAndFalse(0.01f, "heal"));
        }
    }

    public void TakeDamage(float damage)
    {
        animator.SetBool("heal", false);
        animator.SetBool("damage", true);
        health -= damage;
        if (health <= 0)
        {
            /// careful danger zone health is negative without health = 0 here
            dead = true;
            UseCheckpoint();
        }
    }

    public void Heal(float heal)
    {
        animator.SetBool("damage", false);
        animator.SetBool("heal", true);
        health += heal;
        if (health > 6)
            health = 6;
    }

    public IEnumerator ToggleTrueAndFalse(float waitTime, string param)
    {
        if(param == "damage")
        {
            TakeDamage(1);
        }
        else
        {
            Heal(1);
        }
        yield return new WaitForSeconds(waitTime);
        animator.SetBool(param, false);
    }
}
