using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public ItemData currentItem;
    public Transform handSlot; // точка, где будет отображаться предмет
    private GameObject heldItemObject;

    public void PickUp(ItemData item) {
        currentItem = item;

        // Удаляем старый объект из руки
        if (heldItemObject != null) Destroy(heldItemObject);

        // Отображаем новый предмет
        if (item.itemPrefab != null && handSlot != null) {
            heldItemObject = Instantiate(item.itemPrefab, handSlot.position, handSlot.rotation, handSlot);
        }

        Debug.Log("Предмет получен: " + item.itemName);
    }

    public void DropItem() {
        if (heldItemObject != null) {
            Destroy(heldItemObject);
            currentItem = null;
        }
    }
}
