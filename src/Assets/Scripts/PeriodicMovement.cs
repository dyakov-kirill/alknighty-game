using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicMovement : MonoBehaviour
{
    public float distance = 5;
    public bool isHorizontal = true;
    public float speed = 1;
    public bool MovingRight
    {
        get;
        private set;
    }
    private bool movingUp = true;
    private float startPos, endPos;
    public bool isActive = true;
    void Start()
    {
        MovingRight = true;
        if (isHorizontal)
        {
            startPos = transform.position.x;
            endPos = startPos + distance;
        } else
        {
            startPos = transform.position.y;
            endPos = startPos + distance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (isHorizontal)
            {
                if (transform.position.x > endPos)
                {
                    MovingRight = false;
                }
                else if (transform.position.x < startPos)
                {
                    MovingRight = true;
                }

                if (MovingRight)
                {
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                }
            }
            else
            {
                if (transform.position.y > endPos)
                {
                    movingUp = false;
                }
                else if (transform.position.y < startPos)
                {
                    movingUp = true;
                }

                if (movingUp)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
                }
            }
        }
    }
}
