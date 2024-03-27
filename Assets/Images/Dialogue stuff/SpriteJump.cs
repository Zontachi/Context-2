using UnityEngine;

public class JumpOnClick : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust this value to control the jump height

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce; // Apply upward force to jump
    }
}