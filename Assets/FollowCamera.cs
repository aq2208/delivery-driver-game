using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject thingToFollow;

    //this thing's position (camera) should be the same as the car's position
    //we want the following camera in every single frame
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -20);
    }
}
