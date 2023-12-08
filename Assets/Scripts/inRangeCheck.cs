using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inRangeCheck : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private Collider2D inRangeChecker;
    // Start is called before the first frame update
    void Start()
    {
        inRangeChecker = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.enemyInRange = false;
        }
    }

}
