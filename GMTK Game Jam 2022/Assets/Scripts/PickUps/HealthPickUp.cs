using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUps
{
    [SerializeField] private float heal;
    private Health2 health;

    private void Start()
    {
        health = player.GetComponent<Health2>();
    }

    public override void PickUp()
    {
        if(health.health < health.maxHealth)
        {
            health.Heal(heal);
            Destroy(gameObject);
        }
    }
}
