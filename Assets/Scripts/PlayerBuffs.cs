using UnityEngine;

public class PlayerBuffs : MonoBehaviour {
    public PlayerController player; // —сылка на движение
    public PlayerHealth health;     // —сылка на здоровье
    public int baseDamage = 20;
    private int currentDamage;

    void Start() {
        if (player == null) player = GetComponent<PlayerController>();
        if (health == null) health = GetComponent<PlayerHealth>();
        currentDamage = baseDamage;
    }

    public void ApplyBuff(PickUpItem.BuffType type, float amount, float duration, bool isTemporary) {
        switch (type) {
            case PickUpItem.BuffType.Health:
                health.Heal((int)amount);
                break;

            case PickUpItem.BuffType.Speed:
                if (isTemporary)
                    StartCoroutine(TemporarySpeedBoost(amount, duration));
                else
                    player.speed += amount;
                break;

            case PickUpItem.BuffType.Damage:
                if (isTemporary)
                    StartCoroutine(TemporaryDamageBoost((int)amount, duration));
                else
                    baseDamage += (int)amount;
                break;
        }
    }

    private System.Collections.IEnumerator TemporarySpeedBoost(float amount, float duration) {
        player.speed += amount;
        yield return new WaitForSeconds(duration);
        player.speed -= amount;
    }

    private System.Collections.IEnumerator TemporaryDamageBoost(int amount, float duration) {
        baseDamage += amount;
        yield return new WaitForSeconds(duration);
        baseDamage -= amount;
    }

    public int GetCurrentDamage() => baseDamage;
}
