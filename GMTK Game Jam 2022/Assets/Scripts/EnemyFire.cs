using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject target;

    private Vector3 targetPosition, objectPosition;
    private float angle;
    private bool ready = true;
    public bool charge = false;
    public Vector3 chargePosition;

    void Update()
    {
        if(ready)
        {
            if(name == "Particle System")
            {
                GetComponent<ParticleSystem>().Play();
                StartCoroutine(ManualAttackDelay(3));
            }
            if (name == "target")
            {
                StartCoroutine(Charge());
            }
            
        }
        if (charge == true)
        {
            transform.parent.transform.position = Vector2.MoveTowards(transform.parent.transform.position, chargePosition, Time.deltaTime * 10);
        }

        objectPosition = Camera.main.WorldToViewportPoint(transform.position);
        targetPosition = Camera.main.WorldToViewportPoint(target.transform.position);

        angle = Mathf.Atan2(objectPosition.y - targetPosition.y, objectPosition.x - targetPosition.x) * Mathf.Rad2Deg;
        if(name == "Particle System")
            transform.rotation = Quaternion.Euler(new Vector3(-angle - 180, 90, 90));
        if(name == "target")
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject == target)
        {
            target.GetComponent<Health>().TakeDamage(1);
        }
    }

    IEnumerator ManualAttackDelay(float x)
    {
        ready = false;
        yield return new WaitForSeconds(x);
        ready = true;
    }

    IEnumerator Charge()
    {
        ready = false;
        GetComponentInParent<Enemy_Movement>().speed = 0;
        foreach(SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = true;
        }
        yield return new WaitForSeconds(0.5f);
        charge = true;
        chargePosition = target.transform.position;
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
                sprite.enabled = false;
        }
        yield return new WaitForSeconds(2);
        charge = false;
        GetComponentInParent<Enemy_Movement>().speed = 0.5f;
        yield return new WaitForSeconds(6);
        ready = true;
    }
}
