using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSlot : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject currentItem;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        GameObject current = Instantiate(currentItem, transform);
    }

    void Update()
    {

    }
}
