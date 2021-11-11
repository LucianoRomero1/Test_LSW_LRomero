using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Vector2 limitMap;


    private void FixedUpdate()
    {
        FollowCharacter();

        Vector3 positionCamera = transform.position;
        positionCamera.x = Mathf.Clamp(target.position.x, -limitMap.x, limitMap.x);
        positionCamera.y = Mathf.Clamp(target.position.y, -limitMap.y, limitMap.y);

        transform.position = positionCamera;

        //transform.position = new Vector3(
        //    Mathf.Clamp(target.position.x, -70.0f, 32.0f),
        //    Mathf.Clamp(target.position.y, -14.0f, 34.0f),
        //    transform.position.z);


    }

    private void FollowCharacter()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}


