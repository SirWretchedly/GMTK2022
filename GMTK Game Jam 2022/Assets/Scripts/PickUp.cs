using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.tag == "HealthUp")
        {
            StartCoroutine(player.GetComponent<Health>().ToggleTrueAndFalse(0.01f, "heal"));
            Destroy(transform.gameObject);
        }

        if(this.tag == "Upgrade")
        {
            image.SetActive(true);
            player.GetComponent<ChoseUpgrade>().active = true;
            Destroy(transform.gameObject);
        }
    }
}
