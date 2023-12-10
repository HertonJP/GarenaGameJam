using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class enemyAttack : MonoBehaviour
{
    private Collider2D coll;
    public int enemyDamage = 10;
    public CinemachineImpulseSource[] enemyShakeSource;
 
    void Start()
    {
        enemyShakeSource = Camera.main.GetComponents<CinemachineImpulseSource>();
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
    }

    public void activateCollider()
    {
        coll.enabled = true;
    }

    public void deactivateCollider()
    {
        coll.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerStats>().canBeDamaged)
            {
                collision.GetComponent<PlayerStats>().TakeDamage(enemyDamage);
                enemyShakeSource[1].GenerateImpulse();
            }

        }

    }
}
