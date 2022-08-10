using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    private Camera cam;

    private void Start()
    {
        laser = GameObject.FindGameObjectWithTag("Laser");
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

                var ray = cam.ScreenToWorldPoint(touch.position);
                Debug.Log("ray is: " + ray);
                laser.transform.LookAt(ray);
                break;

        }
    }

   
}
