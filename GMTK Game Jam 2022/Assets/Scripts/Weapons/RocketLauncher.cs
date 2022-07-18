using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField] private float speed, angleMod, burstMod;
    [SerializeField] private GameObject explosion, explosionObject, explosionMod;
    private ParticleSystem.ShapeModule shape;
    private ParticleSystem.EmissionModule emission;
    private bool ready = true;
    private List<ParticleCollisionEvent> collisionEvents;

    private void Update()
    {
        if (key != "" && Input.GetKeyDown(key) && ready)
        {
            Fire();
        }
    }

    public override void Upgrade()
    {
        explosionObject = explosionMod;
        shape = GetComponent<ParticleSystem>().shape;
        shape.angle += angleMod;
        emission = GetComponent<ParticleSystem>().emission;
        emission.SetBurst(0, new ParticleSystem.Burst(0, emission.GetBurst(0).count.constantMax + burstMod));
        upgraded = true;
    }

    public override void Fire()
    {
        particles.Play();
        StartCoroutine(FireDelay());
    }

    IEnumerator FireDelay()
    {
        ready = false;
        yield return new WaitForSeconds(speed);
        ready = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        ParticlePhysicsExtensions.GetCollisionEvents(particles, other, collisionEvents);

        explosion = Instantiate(explosionObject);
        explosion.transform.position = collisionEvents[0].intersection;
        StartCoroutine(DeleteExplosion(explosion));
    }

    IEnumerator DeleteExplosion(GameObject explosion)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(explosion);
    }
}
