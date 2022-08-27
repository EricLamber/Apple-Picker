using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;

    void Start() => cam = Camera.main;

    void Update() => transform.position = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    
    void OnTriggerEnter2D(Collider2D other) => Destroy(other.gameObject);
}
