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

    public float attackRange = 1f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;

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

        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1)) {
            AttackNearbyEnemies();
        }
    }

    void FixedUpdate() {
        // Горизонтальное движение (не трогаем вертикальную скорость)
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
    }

    void AttackNearbyEnemies() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemies) {
            EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
            if (eh != null) {
                eh.TakeDamage(attackDamage);
            }
        }
    }
}
