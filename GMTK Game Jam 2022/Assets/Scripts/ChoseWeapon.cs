using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseWeapon : MonoBehaviour
{
    public bool isActive = false;
    public GameObject image;
    public GameObject colliderObject;

    public void SetColliderObject(GameObject obj) {
        colliderObject = obj;
        print("IN SETs FUNCTION");
        if (obj == null) {
            print("!! here !!");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("space") && isActive == true)
        {
            print("Instantiated");

            GameObject colliderCopy = GameObject.Instantiate(colliderObject);

            GameObject auxWeapon = colliderCopy.GetComponent<PickUp>().weapon;
            
            colliderCopy.GetComponent<PickUp>().weapon = GetComponentInChildren<RollingController>().special;
            colliderCopy.tag = "Pickup";
            
            //Instantiate(colliderCopy, colliderCopy.transform.position, colliderCopy.transform.rotation);
            GetComponentInChildren<RollingController>().special = auxWeapon;
            image.SetActive(false);

            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("ToBeDeleted");
            
            for (int i = 0; i < gameObjects.Length; i++) {
                Destroy(gameObjects[i]);
            }
            
            isActive = false;

            GameObject player = GameObject.FindWithTag("Die");
            player.transform.Find("Middle").GetComponent<RollingController>().UpdateSprite();

        }
    }
}
