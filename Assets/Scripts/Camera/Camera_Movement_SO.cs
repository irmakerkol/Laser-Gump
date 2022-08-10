using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CameraMovementSettings", menuName = "ScriptableObjects/CameraSettings", order = 1)]
public class Camera_Movement_SO : ScriptableObject
{
    public GameObject followedObject;
    public Vector3 followDistance;

}
