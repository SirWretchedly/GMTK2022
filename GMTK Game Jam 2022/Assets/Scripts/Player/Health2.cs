using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{
    public Vector2 respawn;
    public float health, maxHealth, invincibility;
    [SerializeField] private Animator animator;
    private bool ready = true;

    private void Start()
    {
        respawn = transform.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            Damage(1);
        }
        if(Input.GetKeyDown("p"))
        {
            Heal(1);
        }
    }

    public void Damage(float amount)
    {
        if(ready)
        {
            health -= amount;
            animator.ResetTrigger("healed");
            animator.SetTrigger("damaged");

            if(health <= 0)
            {
                health = maxHealth;
                transform.position = respawn;
                GetComponent<PlayerController2>().target = transform.position;

                animator.ResetTrigger("damaged");
                animator.Play("6");
            }

            StartCoroutine(Invincibility(invincibility));
        }
        
    }

    public void Heal(float amount)
    {
        health += amount;

        animator.ResetTrigger("damaged");
        animator.SetTrigger("healed");

        if (health > maxHealth)
            health = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage(1);
    }

    IEnumerator Invincibility(float amount)
    {
        ready = false;
        yield return new WaitForSeconds(amount);
        ready = true;
    }
}
