using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    void LateUpdate() {
        if (player != null)
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
