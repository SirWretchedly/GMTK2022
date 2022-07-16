using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private string key;

    private ParticleSystem particles;

    void Update()
    {
        particles = GetComponentInChildren<ParticleSystem>();

        if (key == "up")
            particles.transform.rotation = Quaternion.Euler(-90, 0, 0);
        else if (key == "left")
            particles.transform.rotation = Quaternion.Euler(0, -90, 0);
        else if (key == "right")
            particles.transform.rotation = Quaternion.Euler(0, 90, 0);
        else if (key == "down")
            particles.transform.rotation = Quaternion.Euler(90, 0, 0);

        if (Input.GetKey(key))
        {
            print(particles.name);
            particles.enableEmission = true;
        }
        else
            particles.enableEmission = false;
    }
}
