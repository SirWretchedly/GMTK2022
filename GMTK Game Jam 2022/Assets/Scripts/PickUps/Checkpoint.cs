using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : PickUps
{
    public override void PickUp()
    {
        player.GetComponent<Health2>().respawn = transform.position;
    }
}
