using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Health playerHealth;

    [SerializeField] private float pushForce = 5f;
    [SerializeField] private VirtualCamFollow virtualCamFollow;

    [Space(1), Header("Movement Boundaries")]
    [SerializeField] private float maxHorizontalDistance = 7f;
    [SerializeField] private float maxVerticalDistance = 4.25f;

    float horizontal;
    float vertical;

    public float moveSpeed = 10f;
    public bool isPlayerDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Flip the Sprite if Moving in Opposite Directions
        if (horizontal < 0) GetComponentInChildren<SpriteRenderer>().flipX = true;
        else if (horizontal > 0) GetComponentInChildren<SpriteRenderer>().flipX = false;
    }

    private void FixedUpdate()
    {
        if (!virtualCamFollow.isHeadEntityTweeking)
        {
            if (playerHealth.CurrentHealth > 0)
            { 
                // Setting Player Movement Boundaries
                if ((transform.position.x <= maxHorizontalDistance && transform.position.x >= -maxHorizontalDistance)
                    && (transform.position.y <= maxVerticalDistance && transform.position.y >= -maxVerticalDistance))
                {
                    rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
                }
                // Pushing Player Inside the Boundary
                else if (transform.position.x > maxHorizontalDistance)
                {
                    rb.velocity = Vector2.right * -pushForce;
                }
                else if (transform.position.x < -maxHorizontalDistance)
                {
                    rb.velocity = Vector2.left * -pushForce;
                }
                else if (transform.position.y > maxVerticalDistance)
                {
                    rb.velocity = Vector2.down * pushForce;
                }
                else if (transform.position.y < -maxVerticalDistance)
                {
                    rb.velocity = Vector2.up * pushForce;
                }
            }
            else
            {
                isPlayerDead = true;
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
