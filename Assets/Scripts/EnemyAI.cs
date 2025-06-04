using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float speed = 2f;
    public float chaseDistance = 3f;
    private bool isChasing = false;
    private Transform player;
    private Vector2 direction = Vector2.left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.position);

        if (dist < chaseDistance) {
            isChasing = true;
        }
        else {
            isChasing = false;
        }

        if (isChasing) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else {
            Patrol();
        }
    }

    void Patrol() {
        transform.Translate(direction * speed * Time.deltaTime);

        // Простейшее переключение направления (можно сделать по таймеру или столкновению со стеной)
        if (Random.value < 0.005f) {
            direction *= -1;
        }

        if (direction.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1); // Смотрит вправо
        }
        else if (direction.x < 0) {
            transform.localScale = new Vector3(1, 1, 1); // Смотрит влево (зеркально)
        }
    }
}
