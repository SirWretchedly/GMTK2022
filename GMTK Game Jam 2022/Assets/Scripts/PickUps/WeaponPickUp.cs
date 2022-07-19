using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUps
{
    public GameObject prompt, weapon;
    [SerializeField] private GameObject drop, newWeapon;
    private bool active;
    private RollingController rollingController;
    private Collider2D collider2d;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        collider2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown("space"))
            {
                rollingController = player.GetComponentInChildren<RollingController>();
                drop = rollingController.special;
                newWeapon = Instantiate(weapon);
                rollingController.special = newWeapon;
                newWeapon.transform.position = new Vector2(-1000, -1000);
                rollingController.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;

                if(drop.name != "Empty")
                {
                    weapon = drop;
                    collider2d.enabled = false;
                    GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    Destroy(gameObject);
                }

                prompt.SetActive(false);
                active = false;
            }
        }

        if(collider2d.enabled == false)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 1)
                collider2d.enabled = true;
        }
    }

    public override void PickUp()
    {
        prompt.SetActive(true);
        active = true;
    }
}
