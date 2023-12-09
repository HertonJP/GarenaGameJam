using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private Collider2D coll;
    public int enemyDamage = 10;
    void Start()
    {
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
            collision.GetComponent<PlayerStats>().TakeDamage(enemyDamage);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
