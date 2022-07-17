using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpecs : MonoBehaviour
{
    public bool upgraded = false;
    public float damage;

    public void RateOfFire(int mod)
    {
        if(gameObject.name == "Flamethrower")
        {
            GetComponent<ParticleSystem>().startLifetime += 2;
        }
        if (gameObject.name == "Machine Gun" || gameObject.name == "Laser")
        {
            GetComponent<ParticleSystem>().emissionRate += mod;
        }
        else if(gameObject.name == "Shotgun")
        {
            ParticleSystem.EmissionModule e = GetComponent<ParticleSystem>().emission;
            e.SetBurst(0, new ParticleSystem.Burst(e.GetBurst(0).time, e.GetBurst(0).count.constant + mod / 10));
        }
        else
        {
            ParticleSystem.EmissionModule e = GetComponent<ParticleSystem>().emission;
            e.SetBurst(0, new ParticleSystem.Burst(e.GetBurst(0).time, e.GetBurst(0).count.constant + mod / 50));
        }

        upgraded = true;
    }
}
