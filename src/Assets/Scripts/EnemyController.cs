using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool IsAlive
    {
        get;
        private set;
    }

    private SpriteRenderer sr;
    public Animator anim;
    private PeriodicMovement pm;
    public string DeathSpritePath;
    void Start()
    {
        IsAlive = true;
        sr = GetComponent<SpriteRenderer>();
        pm = GetComponent<PeriodicMovement>();
    }
    void Update()
    {
        if (!pm.MovingRight)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

    public void KillEnemy()
    {
        IsAlive = false;
        GetComponent<PeriodicMovement>().isActive = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        anim.enabled = false;
        sr.sprite = Resources.Load<Sprite>(DeathSpritePath);
        

    }
}
