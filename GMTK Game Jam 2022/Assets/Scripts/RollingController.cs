using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingController : MonoBehaviour
{
    public List<GameObject> stiva1 = new List<GameObject>();
    public List<GameObject> stiva2 = new List<GameObject>();
    public GameObject special;
    public GameObject specialjos;

    SpriteRenderer spriteRenderer;

    private RollingSlot up;
    private RollingSlot down;
    private RollingSlot left;
    private RollingSlot right;

    [SerializeField] private DetectBlock[] detectBlocks;

    void turnLeftUp(int stiva)
    {
        if (stiva == 1)
        {
            /*GameObject x = stiva1[0];
            stiva1.RemoveAt(0);
            stiva1.Add(x);
            GameObject y = stiva1[0];
            stiva1.RemoveAt(0);
            stiva1.Insert(0, special);
            special = y;*/
            GameObject x = specialjos;
            specialjos = stiva1[0];
            stiva1[0] = special;
            special = stiva1[1];
            stiva1[1] = x;
        }
        else
        {
            /*GameObject x = stiva2[0];
            stiva2.RemoveAt(0);
            stiva2.Add(x);
            GameObject y = stiva2[0];
            stiva2.RemoveAt(0);
            stiva2.Insert(0, special);
            special = y;*/
            GameObject x = specialjos;
            specialjos = stiva2[0];
            stiva2[0] = special;
            special = stiva2[1];
            stiva2[1] = x;
        }
    }

    void turnRightDown(int stiva)
    {
        if (stiva == 1)
        {
            /*GameObject x = stiva1[0];
            stiva1.RemoveAt(0);
            stiva1.Insert(0, special);
            special = x;
            GameObject y = stiva1[stiva1.Count - 1];
            stiva1.RemoveAt(stiva1.Count - 1);
            stiva1.Insert(0, y);*/
            GameObject x = specialjos;
            specialjos = stiva1[1];
            stiva1[1] = special;
            special = stiva1[0];
            stiva1[0] = x;

        }
        else
        {
            /*GameObject x = stiva2[0];
            stiva2.RemoveAt(0);
            stiva2.Insert(0, special);
            special = x;
            GameObject y = stiva2[stiva2.Count - 1];
            stiva2.RemoveAt(stiva2.Count - 1);
            stiva2.Insert(0, y);*/
            GameObject x = specialjos;
            specialjos = stiva2[1];
            stiva2[1] = special;
            special = stiva2[0];
            stiva2[0] = x;
        }
    }

    void functiaf(RollingSlot x)
    {
        foreach (Transform child in x.transform)
        {
            StartCoroutine(DeleteDelay(child));
        }
        GameObject current = Instantiate(x.currentItem, x.transform);
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
        if (Input.GetKeyDown("s") && !detectBlocks[2].isBlocked)
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
        if (Input.GetKeyDown("w") && !detectBlocks[0].isBlocked)
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
        if (Input.GetKeyDown("d") && !detectBlocks[1].isBlocked)
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
        if (Input.GetKeyDown("a") && !detectBlocks[3].isBlocked)
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

    IEnumerator DeleteDelay(Transform child)
    {
        child.GetComponent<SpriteRenderer>().enabled = false;
        child.GetComponentInChildren<ParticleSystem>().enableEmission = false;
        yield return new WaitForSeconds(5);
        if(child != null)
            Destroy(child.gameObject);
    }
}