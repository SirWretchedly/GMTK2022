using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseUpgrade : MonoBehaviour
{
    public bool active = false;
    public GameObject image;
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().upgraded == false)
            {
                GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().damage += 1;
                GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
                image.SetActive(false);
                active = false;
            }
        }
    }
}
