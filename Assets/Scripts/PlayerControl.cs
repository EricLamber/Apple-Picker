using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;
    AppleDispenserScript apple;

    void Start() 
    { 
        cam = Camera.main;
        apple = FindObjectOfType<AppleDispenserScript>();
    }

    void Update() => transform.position = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        apple.apples.Enqueue(other.gameObject);
    }
}
