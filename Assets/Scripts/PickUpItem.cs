using UnityEngine;

public class PickUpItem : MonoBehaviour {
    public enum BuffType { Health, Speed, Damage, Item }
    public BuffType buffType;
    public float amount = 20f;
    public float duration = 5f; // дл€ временных эффектов
    public bool isTemporary = false;
    public ItemData itemData;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerBuffs buffs = other.GetComponent<PlayerBuffs>();
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (buffs != null) {
                buffs.ApplyBuff(buffType, amount, duration, isTemporary);
            }

            if (inv != null && itemData != null) {
                inv.PickUp(itemData);
            }

            // Ёффект, звук и удаление
            Destroy(gameObject);
        }
    }
}
