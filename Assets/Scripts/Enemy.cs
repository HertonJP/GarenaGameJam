using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHP = 100;
    public int enemyHP;
    public bool playerInRange = false;
    private Animator anim;
    private Score score;
    private bool isFacingRight = true;
    [SerializeField] private GameObject floatingTextPrefab;
    private Transform target;
    [SerializeField] private Collider2D attackColl;
    private Spawner spawner;
    void Start()
    {
        spawner = GameObject.Find("Manager").GetComponent<Spawner>();
        target = GameObject.Find("Hero").transform;
        score = GameObject.Find("Manager").GetComponent<Score>();
        enemyHP = enemyMaxHP;
        anim = GetComponent<Animator>();
    }

    public void activateCollider()
    {
        attackColl.enabled = true;
    }

    public void deactivateCollider()
    {
        attackColl.enabled = false;
    }
    void Update()
    {
        if (playerInRange)
        {
            anim.SetBool("inRange", true);
        }
        if (!playerInRange)
        {
            anim.SetBool("inRange", false);
        }
        Vector2 direction = (target.position - transform.position).normalized;
        if (playerInRange)
        {
            anim.SetTrigger("isAttack");
        }
        if (enemyHP <= 0)
        {
            Die();
            Destroy(this.gameObject);
        }
        if (direction.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHP -= damage;
        ShowFloatingText(damage.ToString());
    }

    private void Die()
    {
        Debug.Log("Mati");
        spawner.enemiesAlive--;
        score.score += 10;
    }


    private void ShowFloatingText(string text)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        FloatingTextController textController = floatingText.GetComponent<FloatingTextController>();
        textController.Init(text);

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
