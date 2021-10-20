using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum Direction
    {
        Right,  // X증가 // Test : 한글 있어도 안깨짐.
        Left,   // Z증가
    }
    Direction direction = Direction.Right;
    void Start()
    {
        originRotate = transform.rotation;
    }

    public float speed = 5;
    private Quaternion originRotate;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            direction = (direction == Direction.Right) ? Direction.Left : Direction.Right;
            var velocity = GetComponent<Rigidbody>().velocity;
            velocity.x = 0;
            velocity.z = 0;
            GetComponent<Rigidbody>().velocity = velocity;
        }

        transform.rotation = originRotate;

        BallMove();
    }

    private void BallMove()
    {
        Vector3 move = (direction == Direction.Right) ? new Vector3(1, 0, 0) : new Vector3(0, 0, 1);
        transform.Translate(move * speed * Time.deltaTime, Space.Self);
    }
}
