using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingController : MonoBehaviour
{
    public List<GameObject> stiva1 = new List<GameObject>();
    public List<GameObject> stiva2 = new List<GameObject>();
    public GameObject special;

    SpriteRenderer spriteRenderer;

    private RollingSlot up;
    private RollingSlot down;
    private RollingSlot left;
    private RollingSlot right;

    void turnLeftUp(int stiva)
    {
        if (stiva == 1)
        {
            GameObject x = stiva1[0];
            stiva1.RemoveAt(0);
            stiva1.Add(x);
            GameObject y = stiva1[0];
            stiva1.RemoveAt(0);
            stiva1.Insert(0, special);
            special = y;
        }
        else
        {
            GameObject x = stiva2[0];
            stiva2.RemoveAt(0);
            stiva2.Add(x);
            GameObject y = stiva2[0];
            stiva2.RemoveAt(0);
            stiva2.Insert(0, special);
            special = y;
        }
    }

    void turnRightDown(int stiva)
    {
        if (stiva == 1)
        {
            GameObject x = stiva1[0];
            stiva1.RemoveAt(0);
            stiva1.Insert(0, special);
            special = x;
            GameObject y = stiva1[stiva1.Count - 1];
            stiva1.RemoveAt(stiva1.Count - 1);
            stiva1.Insert(0, y);
        }
        else
        {
            GameObject x = stiva2[0];
            stiva2.RemoveAt(0);
            stiva2.Insert(0, special);
            special = x;
            GameObject y = stiva2[stiva2.Count - 1];
            stiva2.RemoveAt(stiva2.Count - 1);
            stiva2.Insert(0, y);
        }
    }

    void functiaf(RollingSlot x)
    {
        foreach (Transform child in x.transform)
        {
            Destroy(child.gameObject);
        }
        GameObject current = Instantiate(x.currentItem, x.transform);
        print(current.name);
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        up = GameObject.FindWithTag("RollingUp").GetComponent<RollingSlot>();
        down = GameObject.FindWithTag("RollingDown").GetComponent<RollingSlot>();
        left = GameObject.FindWithTag("RollingLeft").GetComponent<RollingSlot>();
        right = GameObject.FindWithTag("RollingRight").GetComponent<RollingSlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            turnRightDown(2);
            up.currentItem = stiva2[0];
            down.currentItem = stiva2[1];
            left.currentItem = stiva1[0];
            right.currentItem = stiva1[1];
            spriteRenderer.sprite = special.GetComponent<SpriteRenderer>().sprite;
            functiaf(up);
            functiaf(down);
            functiaf(left);
            functiaf(right);
        }
        if (Input.GetKeyDown("w"))
        {
            turnLeftUp(2);
            up.currentItem = stiva2[0];
            down.currentItem = stiva2[1];
            left.currentItem = stiva1[0];
            right.currentItem = stiva1[1];
            spriteRenderer.sprite = special.GetComponent<SpriteRenderer>().sprite;
            functiaf(up);
            functiaf(down);
            functiaf(left);
            functiaf(right);
        }
        if (Input.GetKeyDown("d"))
        {
            turnRightDown(1);
            up.currentItem = stiva2[0];
            down.currentItem = stiva2[1];
            left.currentItem = stiva1[0];
            right.currentItem = stiva1[1];
            spriteRenderer.sprite = special.GetComponent<SpriteRenderer>().sprite;
            functiaf(up);
            functiaf(down);
            functiaf(left);
            functiaf(right);
        }
        if (Input.GetKeyDown("a"))
        {
            turnLeftUp(1);
            up.currentItem = stiva2[0];
            down.currentItem = stiva2[1];
            left.currentItem = stiva1[0];
            right.currentItem = stiva1[1];
            spriteRenderer.sprite = special.GetComponent<SpriteRenderer>().sprite;
            functiaf(up);
            functiaf(down);
            functiaf(left);
            functiaf(right);
        }
    }
}