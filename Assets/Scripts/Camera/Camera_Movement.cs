using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public GameObject followedObject;
    public Vector3 followDistance;
  

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, followedObject.transform.position + followDistance, Time.deltaTime);
    }

}
