using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public GameObject Enemy;
    private EnemyController ec;
    void Start()
    {
        ec = Enemy.GetComponent<EnemyController>();
    }

    void Update()
    {
        
    }

    public void KillEnemy()
    {
        ec.KillEnemy();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetMouseButtonDown(0) && ec.IsAlive)
        {
            ec.KillEnemy();
        }
    }
}
