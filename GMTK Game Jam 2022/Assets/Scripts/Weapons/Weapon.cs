using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;
    public bool upgraded;
    public string key;
    public ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        if(transform.parent != null)
            key = transform.GetComponentInParent<RollingSlot>().key;
    }

    public abstract void Upgrade();

    public abstract void Fire();
}
