using UnityEngine;

public class PickUpMap : MonoBehaviour {
    public GameObject minimapCamera;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (minimapCamera != null) {
                minimapCamera.SetActive(true); // Включаем карту
                Debug.Log("Миникарта активирована!");
            }
            Destroy(gameObject); // Убираем предмет
        }
    }
}
