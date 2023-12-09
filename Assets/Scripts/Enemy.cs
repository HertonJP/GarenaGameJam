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
    [SerializeField] private GameObject floatingTextPrefab;

    void Start()
    {
        score = GameObject.Find("Manager").GetComponent<Score>();
        enemyHP = enemyMaxHP;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (playerInRange)
        {
            anim.SetTrigger("isAttack");
        }
        if (enemyHP <= 0)
        {
            Die();
            Destroy(this.gameObject);
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
        score.score += 10;
    }


    private void ShowFloatingText(string text)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        FloatingTextController textController = floatingText.GetComponent<FloatingTextController>();
        textController.Init(text);

    }

}
