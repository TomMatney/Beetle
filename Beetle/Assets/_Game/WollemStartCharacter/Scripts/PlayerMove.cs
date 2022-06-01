using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    private Vector3 moveDir;

    public GameObject Holder;
    public Animator animator;

    void Start()
    {
        animator = Holder.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("fire");
            animator.SetTrigger("Chop");
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void Move()
    {
        rb.velocity = moveDir * moveSpeed;
    }

    void Update()
    {
        ProcessInputs();
    }
}
