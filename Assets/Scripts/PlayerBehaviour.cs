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
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Map 1")
        {
            HandleMap1();
        }
        else if (currentScene == "Map 2")
        {
            HandleMap2();
        }
        else if (currentScene == "Map 3")
        {
            HandleMap3();
        }
    }

    // ---------------------- MAP 1 ----------------------
    void HandleMap1()
    {
        // Di chuyển tự động sang phải
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Nhảy khi nhấn chuột trái và đang chạm đất
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // ---------------------- MAP 2 ----------------------
    void HandleMap2()
    {
        // Điều khiển trái/phải
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Nhảy bằng Space nếu đang chạm đất
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // ---------------------- MAP 3 ----------------------
    void HandleMap3()
    {
        // Di chuyển top-down 4 hướng
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    // ---------------------- GROUND CHECK ----------------------
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
