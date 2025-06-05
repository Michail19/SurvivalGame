using UnityEngine;

public enum Faction {
    Player,
    Red,
    Blue
}

public class EnemyAI : MonoBehaviour {
    public float speed = 2f;
    public float jumpForce = 6f;
    public float chaseDistance = 3f;

    private bool isChasing = false;
    private bool isGrounded = false;

    private Transform player;
    private Vector2 direction = Vector2.left;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public int damage = 10;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    public Faction faction;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Попробуем найти GroundCheck, если не назначен
        if (groundCheck == null) {
            groundCheck = transform.Find("GroundCheck");
            if (groundCheck == null)
                Debug.LogWarning("EnemyAI: GroundCheck не найден");
        }
    }

    void Update() {
        // Проверка: стоит ли бот на земле
        if (groundCheck != null) {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        float dist = Vector2.Distance(transform.position, player.position);
        isChasing = dist < chaseDistance;

        if (isChasing) {
            ChasePlayer();
        }
        else {
            Patrol();
        }
    }

    void ChasePlayer() {
        Vector2 moveDir = (player.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(moveDir.x * speed, rb.linearVelocity.y);

        // Прыжок при перепаде по высоте
        if (isGrounded && player.position.y > transform.position.y + 0.5f) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Поворот
        if (moveDir.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveDir.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    void Patrol() {
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        // Прыжок через препятствие (например, случайно)
        if (isGrounded && Random.value < 0.002f) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Случайная смена направления
        if (Random.value < 0.005f) {
            direction *= -1;
        }

        if (direction.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    void OnDrawGizmosSelected() {
        if (groundCheck != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        // Игнорируем самих себя
        if (collision.gameObject == gameObject) return;

        // Получаем скрипт врага
        EnemyAI otherEnemy = collision.gameObject.GetComponent<EnemyAI>();
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        // Если это игрок — атакуем всегда
        if (playerHealth != null) {
            Attack(playerHealth);
            return;
        }

        // Если это другой враг
        if (otherEnemy != null) {
            // Если фракция чужая — атакуем
            if (otherEnemy.faction != this.faction) {
                EnemyHealth health = otherEnemy.GetComponent<EnemyHealth>();
                if (health != null) {
                    Attack(health); // метод наносит урон
                }
            }
        }
    }

    void Attack(MonoBehaviour target) {
    if (Time.time > lastAttackTime + attackCooldown) {
        if (target is EnemyHealth)
            ((EnemyHealth)target).TakeDamage(damage);
        else if (target is PlayerHealth)
            ((PlayerHealth)target).TakeDamage(damage);

        lastAttackTime = Time.time;
    }
}

}
