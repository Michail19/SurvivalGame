using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 1000;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        Debug.Log("����� ������� ����! ��������: " + currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("����� �����!");
        // ��� ����� ������� ���������� �����
        Destroy(gameObject);
    }
}
