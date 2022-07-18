using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private float damageMod, speedMod, velocityMod;
    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.MainModule main;
    private bool fire = false;

    private void Update()
    {
        if(key != "")
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
        emission = GetComponent<ParticleSystem>().emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constantMax + speedMod);
        main = GetComponent<ParticleSystem>().main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(main.startSpeed.constantMax + velocityMod);
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
