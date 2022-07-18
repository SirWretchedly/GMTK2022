using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : PickUps
{
    [SerializeField] private GameObject prompt;
    private bool active;
    private GameObject weapon;
    private RollingController rollingController;

    private void Update()
    {
        if(active)
        {
            if(Input.GetKeyDown("space"))
            {

                rollingController = player.GetComponentInChildren<RollingController>();
                if(rollingController.special.GetComponent<Weapon>().upgraded == false)
                {
                    weapon = Instantiate(rollingController.special);
                    weapon.GetComponent<Weapon>().Upgrade();
                    rollingController.special = weapon;
                    weapon.transform.position = new Vector2(-1000, -1000);

                    prompt.SetActive(false);
                    active = false;
                    Destroy(gameObject);
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
