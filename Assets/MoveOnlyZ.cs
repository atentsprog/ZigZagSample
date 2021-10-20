using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnlyZ : MonoBehaviour
{
    public float x;
    public float y;
    Quaternion rotation;
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        rotation = transform.rotation;
    }

    void LateUpdate()
    {
        var pos = transform.position;
        pos.x = x;
        pos.y = y;
        transform.position = pos;

        transform.rotation = rotation;
    }
}
