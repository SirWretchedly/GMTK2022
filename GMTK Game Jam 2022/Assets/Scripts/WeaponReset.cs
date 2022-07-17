using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReset : MonoBehaviour
{
    public GameObject weapon;
    private void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            if(GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().upgraded == true)
            {
                GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().damage -= 1;
                GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().RateOfFire(-30);
                GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().upgraded = false;
            }

            if (GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().upgraded == true)
            {
                GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().damage -= 1;
                GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().RateOfFire(-30);
                GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().upgraded = false;
            }


            if (GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().upgraded == true)
            {
                GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().damage -= 1;
                GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().RateOfFire(-30);
                GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().upgraded = false;
            }

            if (GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().upgraded == true)
            {
                GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().damage -= 1;
                GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().RateOfFire(-30);
                GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().upgraded = false;
            }


            if (GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().upgraded == true)
            {
                GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().damage -= 1;
                GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().RateOfFire(-30);
                GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().upgraded = false;
            }


            if (GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().upgraded == true)
            {
                GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().damage -= 1;
                GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().RateOfFire(-30);
                GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().upgraded = false;
            }
        }
        /*if (Input.GetKeyDown("o"))
        {
            GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().damage += 1;
            GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
            GetComponentInChildren<RollingController>().special.GetComponentInChildren<WeaponSpecs>().upgraded = false;

            GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().damage += 1;
            GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
            GetComponentInChildren<RollingController>().stiva1[0].GetComponentInChildren<WeaponSpecs>().upgraded = false;

            GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().damage += 1;
            GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
            GetComponentInChildren<RollingController>().stiva1[1].GetComponentInChildren<WeaponSpecs>().upgraded = false;

            GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().damage += 1;
            GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
            GetComponentInChildren<RollingController>().stiva1[2].GetComponentInChildren<WeaponSpecs>().upgraded = false;

            GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().damage += 1;
            GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
            GetComponentInChildren<RollingController>().stiva2[0].GetComponentInChildren<WeaponSpecs>().upgraded = false;

            GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().damage += 1;
            GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().RateOfFire(30);
            GetComponentInChildren<RollingController>().stiva2[1].GetComponentInChildren<WeaponSpecs>().upgraded = false;
        }*/
    }
}
