using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    private Animator animator;
    public float moveSpeed = 5f;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool isMoving = movement.magnitude > 0.1f;
        animator.SetBool("isRunning", isMoving);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}