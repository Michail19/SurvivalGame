using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public ItemData currentItem;
    public ItemData currentItemSword;
    public ItemData currentItemSheld;
    public ItemData currentItemCrown;

    public Transform handSlot; // �����, ��� ����� ������������ 
    public Transform handSlotSword; // �����, ��� ����� ������������ �������
    public Transform handSlotSheld; // �����, ��� ����� ������������ �������
    public Transform handSlotCrown; // �����, ��� ����� ������������ �������

    private GameObject heldItemObject;
    private GameObject heldSword;
    private GameObject heldShield;
    private GameObject heldCrown;

    public void PickUp(ItemData item) {
        currentItem = item;

        if (heldItemObject != null) Destroy(heldItemObject);

        if (item.itemPrefab != null && handSlot != null) {
            heldItemObject = Instantiate(item.itemPrefab, handSlot.position, handSlot.rotation, handSlot);
            heldItemObject.transform.localScale = Vector3.one; // ����� �� ��� �������
        }

        Debug.Log("�������� �������: " + item.itemName);
    }

    public void PickUpSword(ItemData item) {
        currentItemSword = item;

        if (heldSword != null) Destroy(heldSword);

        if (item.itemPrefab != null && handSlotSword != null) {
            heldSword = Instantiate(item.itemPrefab, handSlotSword.position, handSlotSword.rotation, handSlotSword);
            heldSword.transform.localScale = Vector3.one; // ����� �� ��� �������
        }

        Debug.Log("�������� �������: " + item.itemName);
    }

    public void PickUpSheld(ItemData item) {
        currentItemSheld = item;

        if (heldShield != null) Destroy(heldShield);

        if (item.itemPrefab != null && handSlotSheld != null) {
            heldShield = Instantiate(item.itemPrefab, handSlotSheld.position, handSlotSheld.rotation, handSlotSheld);
            heldShield.transform.localScale = Vector3.one; // ����� �� ��� �������
        }

        Debug.Log("�������� �������: " + item.itemName);
    }

    public void PickUpCrown(ItemData item) {
        currentItemCrown = item;

        if (heldCrown != null) Destroy(heldCrown);

        if (item.itemPrefab != null && handSlotCrown != null) {
            heldCrown = Instantiate(item.itemPrefab, handSlotCrown.position, handSlotCrown.rotation, handSlotCrown);
            heldCrown.transform.localScale = Vector3.one; // ����� �� ��� �������
        }

        Debug.Log("�������� �������: " + item.itemName);
    }

    public void DropItem() {
        if (heldItemObject != null) {
            Destroy(heldItemObject);
            currentItem = null;
        }

        if (heldSword != null) {
            Destroy(heldSword);
            currentItemSword = null;
        }

        if (heldShield != null) {
            Destroy(heldShield);
            currentItemSheld = null;
        }

        if (heldCrown != null) {
            Destroy(heldCrown);
            currentItemCrown = null;
        }
    }
}
