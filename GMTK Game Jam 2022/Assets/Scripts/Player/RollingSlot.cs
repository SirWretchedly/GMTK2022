using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSlot : MonoBehaviour
{
    public GameObject currentItem;
    public string key;

    void Start()
    {
        GameObject current = Instantiate(currentItem, transform);
    }
}
