using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 500f; // Adjusted for better jump
    private Rigidbody2D rb;
    private Vector3 originalScale;
    private int jumpsRemaining = 2; // No. of jumps allowed
    private Animator animator;
    private bool isFacingRight;
    private bool grounded;

    private void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>(); // to get access
        animator = GetComponent<Animator>(); // Reference to animator from object
        DontDestroyOnLoad(gameObject);
        originalScale = transform.localScale; // Store the original scale

        // Higher gravity scale for faster falling
        rb.gravityScale = 2f;
    }

    private void Update()
    {
        float direction = Input.GetAxis("Horizontal"); // make bunny player move left & right
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (direction != 0)
        {
            if ((direction > 0 && !isFacingRight) || (direction < 0 && isFacingRight))
            {
                Flip();
            }
        }

        if (direction > 0f)
            transform.localScale = originalScale; // Use the original scale of bunny
        else if (direction < 0f)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset Y velocity before jump
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpsRemaining--;
        }

        // Set animator parameters
        animator.SetBool("RUN", direction != 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumpsRemaining = 2; // Reset jumps
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
