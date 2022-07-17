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
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            //Instantiate(weapon, transform);
        }
    }
}
