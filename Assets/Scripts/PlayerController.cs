using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
    }
}
