using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject ThingToFollow;
    //This thing's position (Camera) should be the same as the car's position
    void LateUpdate()
    {
        transform.position = ThingToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
