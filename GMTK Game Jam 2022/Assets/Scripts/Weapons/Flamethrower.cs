using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    [SerializeField] private float damageMod, angleMod, rangeMod;
    private ParticleSystem.ShapeModule shape;
    private ParticleSystem.MainModule main;
    private bool fire = false;

    private void Update()
    {
        if (key != "")
        {
            if (Input.GetKey(key) && !fire)
            {
                Fire();
            }
            else if (!Input.GetKey(key) && fire)
            {
                StopFire();
            }
        }
    }

    public override void Upgrade()
    {
        damage += damageMod;
        shape = GetComponent<ParticleSystem>().shape;
        shape.angle += angleMod;
        main = GetComponent<ParticleSystem>().main;
        main.startLifetime = new ParticleSystem.MinMaxCurve(main.startLifetime.curveMultiplier + rangeMod, main.startLifetime.curveMin, main.startLifetime.curveMax);
        upgraded = true;
    }

    public override void Fire()
    {
        particles.Play();
        fire = true;
    }

    private void StopFire()
    {
        particles.Stop();
        fire = false;
    }
}
