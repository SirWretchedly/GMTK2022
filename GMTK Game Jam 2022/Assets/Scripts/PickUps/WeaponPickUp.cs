using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUps
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject weapon, drop;
    private bool active;
    private RollingController rollingController;

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown("space"))
            {
                rollingController = player.GetComponentInChildren<RollingController>();
                drop = rollingController.special;
                rollingController.special = Instantiate(weapon);
                rollingController.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<SpriteRenderer>().sprite;

                if(drop.name != "Empty")
                {

                }
            }
        }
    }

    public override void PickUp()
    {
        prompt.SetActive(true);
        active = true;
    }
}
