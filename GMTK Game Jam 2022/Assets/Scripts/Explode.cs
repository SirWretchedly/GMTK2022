using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private List<ParticleCollisionEvent> collisionEvents;
    private GameObject exploded;

    private void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        exploded = Instantiate(explosion, transform);
        exploded.GetComponent<ParticleSystem>().Play();
    }
}
