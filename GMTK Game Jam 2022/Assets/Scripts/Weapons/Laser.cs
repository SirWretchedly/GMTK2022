using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    [SerializeField] private float damageMod, velocityMod, angleMod;
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
        main = GetComponent<ParticleSystem>().main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(main.startSpeed.constantMax - velocityMod);
        shape = GetComponent<ParticleSystem>().shape;
        shape.angle += angleMod;
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
