using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnlyZ : MonoBehaviour
{
    public Transform followTr;
    public Vector3 offset;

    public float x;
    public float y;
    void Start()
    {
        offset = transform.position - followTr.position;
        x = transform.position.x;
        y = transform.position.y;
    }
    private void Update()
    {
        var pos = offset + followTr.position;
        pos.x = x;
        pos.y = y;
        transform.position = pos;
    }
}
