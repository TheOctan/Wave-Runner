using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    [Header("Properies")]
    public float smoothTime = 0.15f;
    public int yOffset = 0;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
	{
        Vector3 targetPosition = player.transform.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
