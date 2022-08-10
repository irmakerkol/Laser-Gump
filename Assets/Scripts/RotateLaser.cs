using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] private float rotateSpeed = 5f;
    public float angle = 0.1f;
    private Quaternion targetRotation;
    private Quaternion initialRot;
    private void Start()
    {
        laser = GameObject.FindGameObjectWithTag("Laser");
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
             
            targetRotation = Quaternion.AngleAxis(angle / 4, Vector3.forward * -1);
             
         }
    }


}
