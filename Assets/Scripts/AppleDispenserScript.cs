using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDispenserScript : MonoBehaviour
{
    [SerializeField] GameObject apple;
    [SerializeField] Transform ApplePoint;
    [SerializeField] int AppleThrowCD = 2;
    [SerializeField] float MoveSpeeed = 1;

    Camera cam;

    float LeftBorder;
    float RightBorder;

    public Queue<GameObject> apples = new Queue<GameObject>();

    void Start()
    {
        cam = Camera.main;
        LeftBorder = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        RightBorder = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane)).x;
        apples.Enqueue(Instantiate(apple, ApplePoint.position, ApplePoint.rotation) as GameObject);
        StartCoroutine(AppleThrow());
    }

    void Update()
    {
        MoveSpeeed = (transform.position.x == Mathf.Clamp(transform.position.x, LeftBorder, RightBorder))? MoveSpeeed : -MoveSpeeed;
        transform.Translate(Vector2.up * MoveSpeeed);
    }


    IEnumerator AppleThrow()
    {
        while (true)
        {
            if (apples.Count == 0)
                apples.Enqueue(Instantiate(apple, ApplePoint.position, ApplePoint.rotation) as GameObject);
            else
            {
                var a = apples.Dequeue();
                a.transform.SetPositionAndRotation(ApplePoint.position, ApplePoint.rotation);
                a.SetActive(true);
            }

            yield return new WaitForSeconds(AppleThrowCD);
        }
    }
}
