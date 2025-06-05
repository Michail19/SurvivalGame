using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;
    private Vector3 respawnPoint = Vector3.zero;

    void Start() {
        currentHealth = maxHealth;
        respawnPoint = new Vector3(0f, 0f, 0f); // ��� ������ ������ ����� �����
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        Debug.Log("����� ������� ����! ��������: " + currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("����� �����! �����������...");
        Respawn();
    }

    void Respawn() {
        transform.position = respawnPoint;
        currentHealth = maxHealth;
        Debug.Log("����� ���������� �� ���������: " + currentHealth);
    }

    public void Heal(int amount) {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("����� ����������� ��������: " + currentHealth);
    }
}
