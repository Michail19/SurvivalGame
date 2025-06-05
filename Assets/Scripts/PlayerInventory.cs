using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public ItemData currentItem;
    public Transform handSlot; // �����, ��� ����� ������������ �������
    private GameObject heldItemObject;

    public void PickUp(ItemData item) {
        currentItem = item;

        // ������� ������ ������ �� ����
        if (heldItemObject != null) Destroy(heldItemObject);

        // ���������� ����� �������
        if (item.itemPrefab != null && handSlot != null) {
            heldItemObject = Instantiate(item.itemPrefab, handSlot.position, handSlot.rotation, handSlot);
        }

        Debug.Log("������� �������: " + item.itemName);
    }

    public void DropItem() {
        if (heldItemObject != null) {
            Destroy(heldItemObject);
            currentItem = null;
        }
    }
}
