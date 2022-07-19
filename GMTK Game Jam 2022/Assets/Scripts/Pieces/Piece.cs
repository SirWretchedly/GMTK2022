using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class Piece : MonoBehaviour
{
    public GameObject player;
    public float cooldown, range, health, invincibility;
    public bool ready = true, ability = false, invincible = false;

    public void SetTarget()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= range)
        {
            GetComponent<AIDestinationSetter>().target = player.transform;
        }
        else
        {
            GetComponent<AIDestinationSetter>().target = transform;
        }          
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 6 && !invincible)
        {
            health -= other.GetComponent<Weapon>().damage;
            if (health <= 0)
                Destroy(gameObject);
            StartCoroutine(Invincibility());
        }
    }

    public abstract void Ability();

    public abstract void Animate();

    public IEnumerator Cooldown()
    {
        ready = false;
        yield return new WaitForSeconds(cooldown);
        ready = true;
    }

    public IEnumerator Invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibility);
        invincible = false;
    }
}
