using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;
    private Vector3 respawnPoint = Vector3.zero;

    void Start() {
        currentHealth = maxHealth;
        respawnPoint = new Vector3(0f, 0f, 0f); // или можешь задать любую точку
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        Debug.Log("Игрок получил урон! Здоровье: " + currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Игрок погиб! Возрождение...");
        Respawn();
    }

    void Respawn() {
        transform.position = respawnPoint;
        currentHealth = maxHealth;
        Debug.Log("Игрок возродился со здоровьем: " + currentHealth);
    }

    public void Heal(int amount) {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Игрок восстановил здоровье: " + currentHealth);
    }
}
