using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyHealth : MonoBehaviour
{
    public float health = 10;

    private bool ready = true;

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(other.GetComponent<WeaponSpecs>().damage);
    }

    IEnumerator TakeDamage(float damage)
    {
        ready = false;
        health -= damage;
        yield return new WaitForSeconds(0.1f);
        ready = true;
    }
}
