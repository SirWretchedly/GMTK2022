using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPosition, objectPosition;
    private float angle;

    private void Start()
    {
        target = GetComponentInParent<Piece>().player;
    }

    void Update()
    {
        objectPosition = Camera.main.WorldToViewportPoint(transform.position);
        targetPosition = Camera.main.WorldToViewportPoint(target.transform.position);

        angle = Mathf.Atan2(objectPosition.y - targetPosition.y, objectPosition.x - targetPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(angle, -90, -90));
    }
}
