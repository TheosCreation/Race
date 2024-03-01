using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_MovementSpeed = 10.0f;
    public Transform orientation;
    private Rigidbody rb;

    public float playerHeight;
    public LayerMask Ground;
    private bool isGrounded;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    private bool readyToJump = true;

    private Vector2 movementDirection;
    private Vector3 playerMoveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);
        ProcessInput();

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = groundDrag * 0.2f;
        }
            
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ProcessInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && readyToJump && isGrounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        playerMoveDirection = transform.forward * movementDirection.y + transform.right * movementDirection.x;

        // on ground
        if(isGrounded)
        {
            rb.AddForce(playerMoveDirection * m_MovementSpeed, ForceMode.Force);
        }
        else if(!isGrounded)
        {
            rb.AddForce(playerMoveDirection * m_MovementSpeed * airMultiplier, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
