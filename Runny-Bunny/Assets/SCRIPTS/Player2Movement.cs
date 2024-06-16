using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Movement : MonoBehaviour
{
    // Character selection fields
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    public int selectedOption = 0;

    // Movement and animation fields
    public float speed = 5f;
    public float jumpForce = 600f; // Adjusted for better jump
    private Rigidbody2D rb;
    private Vector3 originalScale;
    private int jumpsRemaining = 2; // No. of jumps allowed
    private Animator animator;
    private Animator anim;
    private bool isFacingRight;
    private bool grounded; 

    public float KForce;
    public float KCounter;
    public float KTime;

    public bool KnockRight;

    public float BounceUpForce = 15f;

    public Slider StamSlider;
    public Slider MentSlider;

    public Camera Camera;

    // Start is called before the first frame update
    private void Start()
    {       
        // Character selection initialization
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        updateCharacter(selectedOption);

        // Movement initialization
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>(); // to get access
        animator = GetComponent<Animator>(); // Reference to animator from object
        DontDestroyOnLoad(gameObject);
        originalScale = transform.localScale; // Store the original scale

        anim = GetComponent<Animator>();

        // Higher gravity scale for faster falling
        rb.gravityScale = 2f;
    }

    public Vector2 CalculateDirection()
    {
        Vector2 Direction = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Direction.x -= 1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direction.x += 1.0f;
        }

        return Direction.normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        if (KCounter <= 0)
        {
            // Movement logic      

            float direction = Input.GetAxis("HorizontalP2"); // make player move left & right

            rb.velocity = new Vector2(direction * speed, rb.velocity.y);

            if (direction != 0)
            {
                if ((direction > 0 && !isFacingRight) || (direction < 0 && isFacingRight))
                {
                    Flip();
                }
            }

            if (direction > 0f)
                transform.localScale = originalScale; // Use the original scale of the player
            else if (direction < 0f)
                transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

            if (Input.GetKeyDown(KeyCode.UpArrow) && jumpsRemaining > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset Y velocity before jump
                rb.AddForce(new Vector2(0f, jumpForce));
                jumpsRemaining--;
            }

            // Set animator parameters
            //animator.SetBool("RUN", direction != 0);          
        }

        else
        {
            if (KnockRight == true)
            {
                rb.velocity = new Vector2(-KForce, 6);
            }

            if (KnockRight == false)
            {
                rb.velocity = new Vector2(KForce, 6);
            }
        }

        KCounter -= Time.deltaTime;

        anim.SetBool("run", Input.GetAxis("HorizontalP2") != 0);


        if (MentSlider.value > 9)
        {
            Camera.orthographicSize = 8f;
        }

        if (MentSlider.value <= 9)
        {
            Camera.orthographicSize = 7f;
        }

        if (MentSlider.value <= 7)
        {
            Camera.orthographicSize = 6f;
        }

        if (MentSlider.value <= 5)
        {
            Camera.orthographicSize = 5f;
        }

        if (MentSlider.value <= 3)
        {
            Camera.orthographicSize = 4f;
        }


        if (StamSlider.value > 9)
        {
            speed = 13;
        }

        if (StamSlider.value <= 9)
        {
            speed = 11;
        }

        if (StamSlider.value <= 7)
        {
            speed = 10;
        }

        if (StamSlider.value <= 5)
        {
            speed = 8;
        }

        if (StamSlider.value <= 3)
        {
            speed = 5;
        }

    }

    public void OnStamCLick()
    {
        speed++;

        StamSlider.value++;
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

    // Character selection methods
    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
        updateCharacter(selectedOption);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KillCollider")
        {
            rb.AddForce(Vector2.up * BounceUpForce, ForceMode2D.Impulse);

            Debug.Log("Hit");
        }
    }
}
