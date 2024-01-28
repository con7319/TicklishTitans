using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    private float horizontal;
    private float vertical;
    private float moveSpeed;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveSpeed = GameManager.Instance.playerDefaultMoveSpeed;
    }

    private void Update()
    {
        PlayerInput();
        MovePlayer();
    }

    /*private void FixedUpdate()
    {
        MovePlayer();
    }*/

    private void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = transform.forward * vertical + transform.right * horizontal;

        if (Input.GetAxisRaw("Horizontal")<=0 && Input.GetAxisRaw("Vertical")<=0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void MovePlayer()
    {
        rb.AddForce(direction.normalized * moveSpeed, ForceMode.Acceleration);
        
        
        
    }
}
