using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text pointText;
    public int point;
    public float gameOverHeight = 1.3f;
    void Update()
    {
        if (transform.position.y < gameOverHeight)
        {
            Debug.LogWarning("게임 종료");
            return;
        }

        if (Input.anyKeyDown)
        {
            direction = (direction == Direction.Right) ? Direction.Left : Direction.Right;
            var velocity = GetComponent<Rigidbody>().velocity;
            velocity.x = 0;
            velocity.z = 0;
            GetComponent<Rigidbody>().velocity = velocity;

            AddPoint(1);
        }

        transform.rotation = originRotate;

        BallMove();
    }

    public void AddPoint(int addPoint)
    {
        point += addPoint;
        pointText.text = point.ToString();
    }

    private void BallMove()
    {
        Vector3 move = (direction == Direction.Right) ? new Vector3(1, 0, 0) : new Vector3(0, 0, 1);
        transform.Translate(move * speed * Time.deltaTime, Space.Self);
    }
}
