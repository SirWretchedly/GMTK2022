using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/
    public Transform Player;
    // Update is called once per frame
    public float SpaceBetween = 100.5f;
    void Update()
    {
        if (Vector3.Distance(Player.position, transform.position) >= SpaceBetween)
        {
            Vector3 direction = Player.position - transform.position;
            transform.Translate(direction * Time.deltaTime);
        }
    }
}
