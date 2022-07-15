using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DetectBlock[] detectBlocks;

    private void Start()
    {
        detectBlocks = GetComponentsInChildren<DetectBlock>();
    }

    void Update()
    {
        if(Input.GetKeyDown("w") && !detectBlocks[0].isBlocked)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
        else if(Input.GetKeyDown("s") && !detectBlocks[2].isBlocked)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
        else if(Input.GetKeyDown("d") && !detectBlocks[1].isBlocked)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        else if(Input.GetKeyDown("a") && !detectBlocks[3].isBlocked)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
    }
}
