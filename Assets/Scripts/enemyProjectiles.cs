using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 initialDirection;
    [SerializeField] private float projectilesSpeed = 5f;
    [SerializeField] private int projectilesDamage = 5;

    private void FixedUpdate()
    {
        rb.velocity = initialDirection * projectilesSpeed;
    }

    public void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction.normalized;
    }


    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
            if (player != null && player.canBeDamaged)
            {
                other.gameObject.GetComponent<PlayerStats>().TakeDamage(projectilesDamage);
            }
        }

        Destroy(gameObject);
        
    }
}