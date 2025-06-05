using UnityEngine;

public class PickUpItem : MonoBehaviour {
    public enum BuffType { Health, Speed, Damage, Item }
    public BuffType buffType;
    public float amount = 20f;
    public float duration = 5f; // ��� ��������� ��������
    public bool isTemporary = false;
    public ItemData itemData;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerBuffs buffs = other.GetComponent<PlayerBuffs>();
            PlayerInventory inv = other.GetComponent<PlayerInventory>();

            Debug.Log("����� ����� � �������: " + other.name);

            if (inv == null) {
                Debug.LogError(" � ������� " + other.name + " ��� PlayerInventory!");
            }

            if (itemData == null) {
                Debug.LogError(" � �������� " + gameObject.name + " �� �������� ItemData!");
            }

            if (inv != null && itemData != null) {
                Debug.Log("����� ����� � �������: " + gameObject.name);
                if (gameObject.name == "shield_basic_metal") {
                    inv.PickUpSheld(itemData);
                }
                else if (gameObject.name == "crown_gold") {
                    inv.PickUpCrown(itemData);
                }
                else if (gameObject.name == "sword_basic_blue" || gameObject.name == "sword_basic4_blue") {
                    inv.PickUpSword(itemData);
                }
                else {
                    inv.PickUp(itemData);
                }
                Destroy(gameObject);
            }

            if (buffs != null) {
                buffs.ApplyBuff(buffType, amount, duration, isTemporary);
            }

            //if (inv != null && itemData != null) {
            //    inv.PickUp(itemData);
            //    Debug.Log(": " + inv);
            //}

            // ������, ���� � ��������
            Destroy(gameObject);
        }
    }
}
