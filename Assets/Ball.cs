using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum Direction
    {
        Right,
        Left,
    }
    Direction direction = Direction.Right;

    public float speed = 5;
    void Update()
    {
        if(Input.anyKeyDown)
        {
            direction = (direction == Direction.Right) ? Direction.Left : Direction.Right;
        }

        BallMove();
    }

    private void BallMove()
    {
        Vector3 move = (direction == Direction.Right) ? new Vector3(1, 0, 0) : new Vector3(0, 0, 1);
        transform.Translate(move * speed * Time.deltaTime, Space.Self);
    }
}
