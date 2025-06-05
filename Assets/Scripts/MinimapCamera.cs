using UnityEngine;

public class MinimapFollow : MonoBehaviour {
    public Transform target;

    void LateUpdate() {
        if (target != null) {
            Vector3 newPos = target.position;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
}
