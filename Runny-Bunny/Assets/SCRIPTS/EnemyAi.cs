using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public float speed;
    public float distanceBetween;
    public float knockbackForce = 10f; // Knockback force to apply to the player

    private float distance;
    private float distance2;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize if needed
    }

    // Update is called once per frame
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);        
        Vector2 direction = (Vector2)(player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Convert to degrees

        distance2 = Vector2.Distance(transform.position, player2.transform.position);
        Vector2 direction2 = (Vector2)(player2.transform.position - transform.position).normalized;
        float angle2 = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg; // Convert to degrees

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }       
        else if (distance2 < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                knockbackDirection.y = 0; // Ensure the knockback is only horizontal
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
