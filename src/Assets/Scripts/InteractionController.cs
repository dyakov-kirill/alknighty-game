using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    PlayerController pc;
    MovementController mc;
    public GameObject UI;
    private UIController uc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pc = GetComponent<PlayerController>();
        mc = GetComponent<MovementController>();
        uc = UI.gameObject.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!pc.IsAlive || pc.IsWon) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Killer"))
        {
            DamagePlayerByKiller();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyController>().IsAlive)
            {
                DamagePlayerByEnemy();
            }
        }
        else if (collision.gameObject.tag.Equals("MSpears"))
        {
            DamagePlayerByKiller();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            pc.AddCoin();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            pc.SetKey();
            collision.gameObject.SetActive(false);

        } 
        else if (collision.gameObject.CompareTag("Mushroom") && pc.Health < 3)
        {
            pc.AddHealth();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Tip") && pc.GotKey)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.6f);
        }
        else if (collision.gameObject.CompareTag("Spawner"))
        {
            collision.gameObject.GetComponent<RockSpawner>().CreateRock();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tip") && pc.GotKey)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MSpears"))
        {
            DamagePlayerByKiller();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door") && pc.GotKey && Input.GetMouseButtonDown(1))
        {
            collision.gameObject.GetComponent<DoorController>().OpenDoor();
            pc.SetKey();
        } else if (collision.gameObject.tag.Equals("Chest") && pc.GotKey && Input.GetMouseButtonDown(1))
        {
            collision.gameObject.GetComponent<ChestController>().OpenChest();
            uc.SetWinText();
            pc.SetKey();
        }
    }

    public void DamagePlayerByEnemy()
    {
        rb.AddForce(new Vector2(-Mathf.Sign(mc.lastDir) * 5, 5), ForceMode2D.Impulse);
        sr.color = Color.red;
        pc.DamagePlayer();
        Invoke("SetWhite", 0.5f);
    }

    public void DamagePlayerByKiller()
    {
        rb.AddForce(new Vector2(Mathf.Sign(mc.lastDir) * 5, 3), ForceMode2D.Impulse);
        sr.color = Color.red;
        pc.DamagePlayer();
        Invoke("SetWhite", 0.5f);
    }

    private void SetWhite()
    {
        if (pc.IsAlive)
        {
            sr.color = Color.white;
        }
    }
}
