using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    [SerializeField] private float speed, damageMod, bounceMod, accuracyMod;
    private ParticleSystem.CollisionModule collision;
    private ParticleSystem.ShapeModule shape;
    private bool ready = true;

    private void Update()
    {
        if (key != "" && Input.GetKeyDown(key) && ready)
        {
            Fire();
        }
    }

    public override void Upgrade()
    {
        damage += damageMod;
        shape = GetComponent<ParticleSystem>().shape;
        shape.angle -= accuracyMod;
        collision = GetComponent<ParticleSystem>().collision;
        collision.bounce = new ParticleSystem.MinMaxCurve(collision.bounce.constantMax + bounceMod);
        collision.lifetimeLoss = 0;
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
}
