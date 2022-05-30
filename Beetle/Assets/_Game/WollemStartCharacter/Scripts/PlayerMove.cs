using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    private Vector3 moveDir;

    private void FixedUpdate()
    {
        Move();
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

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
}
