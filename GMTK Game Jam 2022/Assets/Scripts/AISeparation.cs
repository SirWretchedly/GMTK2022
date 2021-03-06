using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISeparation : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] Enemies;
    public float spaceBetween = 10.0f;
    public Transform Player;
    public float rotationSpeed;
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject enemy in Enemies)
        {
            if(enemy != gameObject)
            {
                float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
                if(distance <= spaceBetween)
                {
                    Vector3 direction = transform.position - enemy.transform.position;
                    //transform.RotateAround(Player.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
                    transform.Translate(direction * Time.deltaTime);
                    

                }
            }
        }
    }
}
