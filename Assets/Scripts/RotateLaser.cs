using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    private Camera cam;
    [SerializeField] private float rotateSpeed = 5f;
    public float angle = 100f;
    private Quaternion targetRotation;
    private Quaternion initialRot;
    private void Start()
    {
        laser = GameObject.FindGameObjectWithTag("Laser");
        cam = Camera.main;
        initialRot = transform.rotation;
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
           Swing();
           transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRot, rotateSpeed * Time.deltaTime);
        }


         void Swing()
         {
             
             targetRotation = Quaternion.AngleAxis(angle, Vector3.forward * -1);
             
             
         }
    }


}
