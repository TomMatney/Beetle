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

    public bool walk = false;


    void Start()
    {
        animator = Holder.GetComponent<Animator>();
    }

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

    void WalkAnim()
    { 
        if (moveDir != Vector3.zero)
        {
            //walk = true;
            animator.SetBool("Walk", true);
            Debug.Log("true");
        }
        else
        {
            animator.SetBool("Walk", false);
            //walk = false;
            Debug.Log("false");
        }
    }
    
    

    void Move()
    {
        rb.velocity = moveDir * moveSpeed;
        
    }

    void Update()
    {
        ProcessInputs();
        WalkAnim();
    }
}
