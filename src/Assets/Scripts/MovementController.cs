using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;

    Rigidbody2D rb;
    SpriteRenderer sr;
    public Animator anim;
    PlayerController pc;
    public float lastDir
    {
        get;
        private set;
    }
    public GameObject LeftTrigger, RightTrigger;
    public float movement = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pc = GetComponent<PlayerController>();
        lastDir = 1;
    }

    void Update()
    {
        if (pc.IsAlive)
        {
            movement = Input.GetAxis("Horizontal");

            if (movement != 0)
            {
                anim.SetBool("stop", false);
            }
            else
            {
                anim.SetBool("stop", true);
            }

            transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.05f)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            if (movement > 0)
            {
                sr.flipX = false;
                lastDir = movement;
            }
            else if (movement < 0)
            {
                sr.flipX = true;
                lastDir = movement;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            this.transform.parent = null;
        }

    }

  
}
