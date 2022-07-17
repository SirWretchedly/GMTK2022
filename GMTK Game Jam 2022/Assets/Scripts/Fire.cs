using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private string key;

    private ParticleSystem particles;
    private ParticleSystem[] particleses;
    private bool ready = true;

    void Update()
    {
        particleses = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem p in particleses)
            if (p.GetComponentInParent<SpriteRenderer>().enabled == true)
                particles = p;
        
        AudioSource audio = particles.gameObject.GetComponent<AudioSource>();

        if (key == "up")
            particles.transform.rotation = Quaternion.Euler(-90, 0, 0);
        else if (key == "left")
            particles.transform.rotation = Quaternion.Euler(0, -90, 0);
        else if (key == "right")
            particles.transform.rotation = Quaternion.Euler(0, 90, 0);
        else if (key == "down")
            particles.transform.rotation = Quaternion.Euler(90, 0, 0);
        
        if(particles.name == "Rocket Launcher")
        {
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(1.5f));
            }
        }
        else if (particles.name == "Grenade Launcher")
        {
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(1));
            }
        }
        else if (particles.name == "Shotgun")
        {
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(0.5f));
            }
        }
        else if (particles.name == "Gun")
        {
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(0.3f));
            }
        }
        else if (particles.name == "Sniper")
        {
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(1.5f));
            }
        }
        else if(particles.name == "Lightning")
        {
            print("poop");
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(0f));
            }
            else if (!Input.GetKey(key))
            {
                audio.Stop();
                particles.Stop();
            }
        }
        else
        {
            if (Input.GetKey(key) && ready)
            {
                audio.Play();
                particles.Play();
                StartCoroutine(ManualAttackDelay(0f));
            }
            else if(!Input.GetKey(key))
            {
                audio.Stop();
                particles.Stop();
            }
        }
    }

    IEnumerator ManualAttackDelay(float x)
    {
        ready = false;
        yield return new WaitForSeconds(x);
        ready = true;
    }
}
