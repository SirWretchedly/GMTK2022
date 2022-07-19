using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour
{
    [SerializeField] private GameObject pickUp, pickUpInstance, prompt, empty;
    private RollingController roller;
    private GameObject weapon;

    private void Start()
    {
        roller = GetComponentInChildren<RollingController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            weapon = roller.special;
            if(weapon.name != "Empty")
            {
                pickUp = Instantiate(pickUpInstance);
                pickUp.GetComponent<WeaponPickUp>().player = gameObject;
                pickUp.GetComponent<WeaponPickUp>().prompt = prompt;
                pickUp.GetComponent<WeaponPickUp>().weapon = weapon;
                pickUp.transform.position = transform.position;
                pickUp.GetComponent<Collider2D>().enabled = false;

                roller.special = empty;
                transform.Find("RollingController").GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}
