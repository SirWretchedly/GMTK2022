using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject image;
    [SerializeField] public GameObject weapon;

    void UpdateSprite()
    {
        if (weapon != null)
        {
            this.transform.Find("PickupSprite").GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }
    }

    private void Update()
    {
        if (weapon != null && weapon.name == "Asset_23")
            Destroy(gameObject);
        //GetComponent<Collider2D>().enabled = false;
    }

    void Start()
    {
        UpdateSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Die")
        {
            if (this.tag == "HealthUp")
            {
                print("HEALTH");
                StartCoroutine(player.GetComponent<Health>().ToggleTrueAndFalse(0.01f, "heal"));
                Destroy(transform.gameObject);
            }

            if (this.tag == "Checkpoint")
            {
                print("Checkpoint");
                player.GetComponent<Health>().checkPointPos = transform.position;
            }

            if (player.GetComponent<ChoseUpgrade>().active == false &&
            player.GetComponent<ChoseWeapon>().isActive == false)
            {

                if (this.tag == "Upgrade")
                {
                    image.SetActive(true);
                    player.GetComponent<ChoseUpgrade>().active = true;
                    Destroy(transform.gameObject);
                }

                if (this.tag == "Pickup")
                {
                    player.GetComponent<ChoseWeapon>().isActive = true;
                    player.GetComponent<ChoseWeapon>().SetColliderObject(transform.gameObject);
                    this.tag = "ToBeDeleted";
                    image.SetActive(true);
                }
            }
        }

        

    }
    public IEnumerator poop()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = true;
    }

}