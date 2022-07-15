using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 6;

    private bool dead = false;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            dead = true;
    }
}
