using UnityEngine;

public class VoidScript : MonoBehaviour
{
    AppleDispenserScript apple;

    void Start() =>
        apple = FindObjectOfType<AppleDispenserScript>();
    

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        apple.apples.Enqueue(other.gameObject);
    }
}
