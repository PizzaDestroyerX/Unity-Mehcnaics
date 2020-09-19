using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector2 offset = Vector2.zero;
   

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x + offset.x, objectToFollow.position.y + offset.y, transform.position.z);
    }
}
