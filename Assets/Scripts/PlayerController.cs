using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Transform groundCheck;         // Точка проверки земли
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;         // Слой земли
    private bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null) {
            groundCheck = transform.Find("GroundCheck");
        }
    }

    void Update() {
        // Горизонтальное движение
        movement.x = Input.GetAxisRaw("Horizontal");

        // Проверка земли
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Прыжок
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.linearVelocity = new Vector2(movement.x * speed * jumpForce, jumpForce);
        }

        // Поворот по направлению
        if (movement.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1); // Смотрит вправо
        }
        else if (movement.x < 0) {
            transform.localScale = new Vector3(1, 1, 1); // Смотрит влево
        }
    }

    void FixedUpdate() {
        // Горизонтальное движение (не трогаем вертикальную скорость)
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }
}
