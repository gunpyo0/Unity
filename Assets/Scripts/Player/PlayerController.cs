using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int jumpCount = 0;

    [Header("GameObject")]
    [SerializeField] private GameObject fireRotation;

    [Header("Raycast")]
    [SerializeField] private LayerMask groundLayer;
    private RaycastHit2D hit;
    private bool isGround = false;

    [Header("Jump Buffering")]
    [SerializeField] private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    [SerializeField] private float coyoteTime = 0.1f;
    private float coyoteCounter;

    private CapsuleCollider2D capsuleCollider;
    private Rigidbody2D playerRigidbody;

    private GameManager gameManager = GameManager.Instance;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        CheckGround();
        Move();
        JumpInput();
        JumpAction();
    }

    private void CheckGround()
    {
        float rayLength = capsuleCollider.bounds.extents.y + 0.05f; 

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red, 1f);
        isGround = hit.collider != null; 
        if (isGround && jumpCount != 1) jumpCount = 0;
    }

    private void Move()
    {
        float inputH = Input.GetAxisRaw("Horizontal");

        bool playerMoving = inputH != 0;
        if (playerMoving)
        {
            FireRotate(inputH);
            playerRigidbody.velocity = new Vector2(inputH * moveSpeed, playerRigidbody.velocity.y);

        }
        else
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime; 
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    private void JumpAction()
    {
        if (jumpBufferCounter > 0 && (isGround || coyoteCounter > 0))
        {
            if (jumpCount >= 2) return;

            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            jumpCount++;
            jumpBufferCounter = 0;
            coyoteCounter = 0;
        }
    }

    private void FireRotate(float inputH)
    {
        switch (inputH)
        {
            case > 0:
                fireRotation.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case < 0:
                fireRotation.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
        }

    }
}

    //private void IsGround()
    //{
    //    hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
    //    Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red, 1);
    //    isGround = hit.collider != null;

    //    if (isGround)
    //    {
    //        jumpCount = 0;
    //    }
    //}

    //private void Jump()
    //{

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (jumpCount >= 2) return;
    //        jumpCount++;
    //        playerRigidbody.velocity = Vector3.zero;
    //        playerRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    //    }
    //}