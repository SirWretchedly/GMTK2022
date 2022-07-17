using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyHealth : MonoBehaviour
{
    public float health = 10;

    private bool ready = true;

    public GameObject text;

    private void OnParticleCollision(GameObject other)
    {
        if(ready)
        {
            StartCoroutine(TakeDamage(other.GetComponent<WeaponSpecs>().damage));
        }
        
    }

    IEnumerator TakeDamage(float damage)
    {
        ready = false;
        health -= damage;
        if (transform.name == "King" && health <= 0)
        {
            text.SetActive(true);
            Destroy(transform.gameObject);
        }
            
        if (health <= 0)
            Destroy(transform.gameObject);
        yield return new WaitForSeconds(0.1f);
        ready = true;
    }
}
