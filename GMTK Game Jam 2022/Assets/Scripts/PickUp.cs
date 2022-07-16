using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.name == "HealthUp")
        {
            player.GetComponent<Health>().Heal(1);
            Destroy(transform.gameObject);
        }

        if(this.name == "Upgrade")
        {
            player.transform.Find("Middle").GetComponent<RollingController>().stiva1[1].GetComponent<RollingSlot>().currentItem.GetComponent<ParticleSystem>().emissionRate += 0.5f;
            Destroy(transform.gameObject);
        }
    }
}
