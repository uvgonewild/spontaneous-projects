using UnityEngine;

public class CandyBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private VirtualCamFollow virtualCamFollow;

    public float moveForce;
    
    private Camera cam;

    private PlayerAttack playerAttack;
    private Vector2 throwDirection;
    private Vector2 mousePos;

    void Awake()
    {
        #region Finding and Accessing Objects

        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        virtualCamFollow = GameObject.Find("VirtualCamFollow").GetComponent<VirtualCamFollow>();
        rb = GetComponent<Rigidbody2D>();


        #endregion

        GetComponent<AudioSource>().Play();

        // Getting Position in Terms of Vectors
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        throwDirection = mousePos - new Vector2(playerAttack.transform.position.x, playerAttack.transform.position.y);

        // Calculating angle of the Resultant Vector
        float throwAngle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = throwAngle;

        // Destroying the Gameobject
        Invoke("SelfDestruct", 2f);
    }

    void Update()
    {
        if (!virtualCamFollow.isHeadEntityTweeking)
        {
            Vector2 movement = new Vector2(transform.forward.x, transform.forward.y);
            rb.AddForce(transform.up * moveForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
