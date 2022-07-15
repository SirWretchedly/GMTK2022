using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private string key;

    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.enableEmission = false;
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            particles.enableEmission = true;
        }   
        else
            particles.enableEmission = false;
    }
}
