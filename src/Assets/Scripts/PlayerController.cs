using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsAlive
    {
        get;
        private set;
    }
       
    public int Health
    {
        get;
        private set;
    }
    public int Coins
    {
        get;
        private set;
    }

    public Animator anim;
    public GameObject UI;
    public GameObject DeathText;
    public GameObject Shade;
    private UIController uc;
    public bool GotKey
    {
        get;
        private set;
    }

    public bool IsWon = false;

    void Start()
    {
        IsAlive = true;
        Health = 3;
        Coins = 0;
        GotKey = false;
        uc = UI.GetComponent<UIController>();
    }
    void Update()
    {
        if (Health <= 0)
        {
            KillPlayer();

        } 
        
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("punch", true);
            Invoke("SetFalse", 0.3f);
        }
    }

    public void KillPlayer()
    {
        if (IsAlive)
        {
            IsAlive = false;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.red;
            transform.Rotate(0, 0, 90);
            anim.enabled = false;
            uc.SetDeathText();
        }
    }

    public void SetKey()
    {
        GotKey = !GotKey;
    }

    public void DamagePlayer()
    {
        Health--;
    }

    public void AddCoin()
    {
        Coins++;
    }

    public void AddHealth()
    {
        Health++;
    }

    public void SetFalse()
    {
        anim.SetBool("punch", false);
    }

}
