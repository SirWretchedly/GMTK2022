using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBlock : MonoBehaviour
{ 
    public bool isBlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            isBlocked = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            isBlocked = false;
    }
}
