using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private GameObject exploded;
    private ParticleSystem particles;
    private List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(this.name == "Grenade Launcher" && other.tag == "Enemy")
        {
            exploded = Instantiate(explosion);
            exploded.transform.position = other.transform.position;
            exploded.GetComponent<ParticleSystem>().Play();
            StartCoroutine(WaitAndKill(exploded));
        }
        else if(this.name == "Rocket Launcher")
        {
            collisionEvents = new List<ParticleCollisionEvent>();

            ParticlePhysicsExtensions.GetCollisionEvents(particles, other, collisionEvents);

            exploded = Instantiate(explosion);
            exploded.transform.position = collisionEvents[0].intersection;
            exploded.GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator WaitAndKill(GameObject explosion)
    {
        yield return new WaitForSeconds(1);
        Destroy(explosion);
    }
}
