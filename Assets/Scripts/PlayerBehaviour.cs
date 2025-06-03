using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Map 1")
        {
     string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Map 1")
        {
            // Tự động di chuyển và nhảy khi bấm chuột (Map 1)

            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

            if (Input.GetMouseButtonDown(0) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isGrounded = false;
            }
        }


        else if (sceneName == "Map 2")
        {
            // Điều khiển trái phải và nhảy thủ công (Map 2)
            float moveX = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isGrounded = false;
            }
        }
        else if (sceneName == "Map 3")
        {
            // Điều khiển 2D cả X và Y (Map 3)
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
