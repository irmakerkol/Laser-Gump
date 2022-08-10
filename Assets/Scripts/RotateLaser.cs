using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    private float pressTime = 0;

    private Camera cam;

    private void Start()
    {
      
        cam = Camera.main;
    }

    void Update()
    {
        moveAfterLongTouch();
    }

    void moveAfterLongTouch()
    {

        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);

        switch (touch.phase)
        {

            case TouchPhase.Began:
                pressTime = 0;
                break;

            case TouchPhase.Stationary:
                pressTime += Time.deltaTime;
                var ray = cam.ScreenToWorldPoint(touch.position);
                Debug.Log("ray is: " + ray);
                this.transform.LookAt(ray);
                break;

            case TouchPhase.Ended:

            case TouchPhase.Canceled:
            break;
        }
    }

   
}
