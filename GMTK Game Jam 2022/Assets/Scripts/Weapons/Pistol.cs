using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private float speed, damageMod, speedMod, accuracyMod;
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
        speed -= speedMod;
        shape = GetComponent<ParticleSystem>().shape;
        shape.angle -= accuracyMod;
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
