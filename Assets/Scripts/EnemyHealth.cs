using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 50;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} получил урон! HP: {currentHealth}");

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log($"{gameObject.name} уничтожен!");
        Destroy(gameObject);
    }
}
