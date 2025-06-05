using UnityEngine;

public class PickUpMap : MonoBehaviour {
    public GameObject minimapCamera;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (minimapCamera != null) {
                minimapCamera.SetActive(true); // �������� �����
                Debug.Log("��������� ������������!");
            }
            Destroy(gameObject); // ������� �������
        }
    }
}
