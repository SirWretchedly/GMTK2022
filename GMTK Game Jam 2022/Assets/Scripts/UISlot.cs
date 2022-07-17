using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    Image spriteRenderer;
    public GameObject currentItem;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
        GameObject current = Instantiate(currentItem, transform);
    }

    void Update()
    {

    }
}
