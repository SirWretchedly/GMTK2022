using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float speed, damageMod, angleMod, burstMod;
    private ParticleSystem.ShapeModule shape;
    private ParticleSystem.EmissionModule emission;
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
}
