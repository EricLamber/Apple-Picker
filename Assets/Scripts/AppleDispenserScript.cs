using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDispenserScript : MonoBehaviour
{
    [SerializeField] GameObject apple;
    [SerializeField] GameObject ApplePoint;
    [SerializeField] int AppleThrowCD = 2;
    [SerializeField] float MoveSpeeed = 1;

    Camera cam;

    float LeftBorder;
    float RightBorder;

    void Start()
    {
        cam = Camera.main;
        LeftBorder = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        RightBorder = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane)).x;
        StartCoroutine(AppleThrow());
    }

    void Update()
    {
        MoveSpeeed = (transform.position.x <= LeftBorder) || (transform.position.x >= RightBorder) ? -MoveSpeeed : MoveSpeeed;
        transform.Translate(Vector2.up * MoveSpeeed);
    }


    IEnumerator AppleThrow()
    {
        while (true)
        {
            Instantiate(apple, ApplePoint.transform.position, ApplePoint.transform.rotation);
            yield return new WaitForSeconds(AppleThrowCD);
        }
    }
}
