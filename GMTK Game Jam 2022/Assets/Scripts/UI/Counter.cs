using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private float time = 0;

    void Update()
    {
        GetComponent<Text>().text = ((int)time).ToString();
        time += Time.deltaTime;
    }
}
