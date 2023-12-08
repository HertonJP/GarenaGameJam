using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool playerInRange = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (playerInRange)
        {
            anim.SetTrigger("isAttack");
        }
    }
}
