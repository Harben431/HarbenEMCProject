using UnityEngine;
using UnityEngine.UI; // To handle UI elements

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    public Text winText;  // Reference to the UI text

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winText.text = "";  // Initially, no message is shown
    }

    void Update()
    {
        // Get horizontal input (left/right movement)
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jump when the space bar is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Detect collision with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detect when the player touches the goal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            winText.text = "You Win!";  // Show the win message
        }
    }
}