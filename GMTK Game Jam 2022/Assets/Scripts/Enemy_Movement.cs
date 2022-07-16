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

    public float speed = 0.5f;
    private bool ready = true;
    private bool jump = false;

    // Update is called once per frame
    public float SpaceBetween = 100.5f;
    private Vector2 offset = new Vector3(0, 0, 0);
    public float rotationSpeed;
    void Update()
    {
        if(name == "Knight")
        {
            if(ready)
            {
                StartCoroutine(KnightJump());
            }

            if(jump)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 10);
                transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime, transform.localScale.z);
            }       
            else if(transform.position.z > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 10);
                
            }
            if(!jump && transform.localScale.x > 1)
                transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime, transform.localScale.y - Time.deltaTime, transform.localScale.z);

        }

        if (Vector3.Distance(Player.position, transform.position) >= SpaceBetween)
        {
            Vector3 direction = new Vector3(Player.position.x - transform.position.x + offset.x, Player.position.y - transform.position.y + offset.y);
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    IEnumerator KnightJump()
    {
        ready = false;
        jump = true;
        speed += 1.5f;
        if(transform.position.x - Player.transform.position.x > 0.5)
            offset = new Vector2(0, 5);
        else
            offset = new Vector2(5, 0);
        yield return new WaitForSeconds(0.3f);
        offset = new Vector2(0, 0);
        speed -= 1.5f;
        jump = false;
        yield return new WaitForSeconds(4);
        ready = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == Player)
        {
            Player.GetComponent<Health>().TakeDamage(1);
        }
        else
        {
            transform.RotateAround(Player.transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }
    }
}
