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
            GetComponent<ParticleSystem>().startLifetime += mod/30;
            ParticleSystem.ShapeModule s = GetComponent<ParticleSystem>().shape;
            s.angle += mod/3;
        }
        else if (gameObject.name == "Machine Gun" || gameObject.name == "Lightning")
        {
            GetComponent<ParticleSystem>().emissionRate += mod;
        }
        else if(gameObject.name == "Laser")
        {
            GetComponent<ParticleSystem>().startSize += mod/15;
        }
        else if(gameObject.name == "Shotgun")
        {
            ParticleSystem.ShapeModule s = GetComponent<ParticleSystem>().shape;
            s.angle += mod / 2;
        }
        else if(gameObject.name == "Grenade Launcher")
        {
            ParticleSystem.EmissionModule e = GetComponent<ParticleSystem>().emission;
            e.SetBurst(0, new ParticleSystem.Burst(e.GetBurst(0).time, e.GetBurst(0).count.constant + mod / 15));
        }
        else
        {
            ParticleSystem.ShapeModule s = GetComponent<ParticleSystem>().shape;
            s.angle += mod / 6;
            ParticleSystem.EmissionModule e = GetComponent<ParticleSystem>().emission;
            e.SetBurst(0, new ParticleSystem.Burst(e.GetBurst(0).time, e.GetBurst(0).count.constant + mod / 15));
        }

        upgraded = true;
    }
}
