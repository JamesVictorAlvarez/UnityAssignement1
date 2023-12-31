using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float mouseSensitivy = 5.0f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    public CharacterController controller;
    private float walkSpeed = 5;
    private float runSpeed = 8;
    private Animator animator;
    private bool jumped = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        UpdateRotation();
        ProcessMovement();
    }
    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivy, 0, Space.Self);

    }

    void ProcessMovement()
    {
        // Moving the character forward according to the speed
        float speed = GetMovementSpeed();

        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Make sure to flatten the vectors so that they don't contain any vertical component
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize the vectors to ensure consistent speed in all directions
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on input and camera orientation
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));

        // Apply the movement direction and speed
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            float mag = Mathf.Clamp01(moveDirection.magnitude);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                mag /= 2;
            }
            animator.SetFloat("Speed", mag);
            float speed1 = Mathf.Clamp01(moveDirection.magnitude) * 7;
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            animator.SetBool("inAir", false);
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isGrounded", false);
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                jumped = true;
            }
            else
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        }
        else
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
            
            bool allowedDoubleJump = GameManager.instance.GetDoubleJump();
            if (Input.GetButtonDown("Jump") && jumped == true && allowedDoubleJump == true)
            {
                animator.SetBool("inAir", true);
                GameManager.instance.DoubleJumpChangeStatus();
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                jumped = false;
            }
            animator.SetBool("isGrounded", true);
        }
        // Apply gravity and move the character
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}