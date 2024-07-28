using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float maxX;
    public float smoothSpeed = 0.125f;

    private float _minX;

    private void Start()
    {
        _minX = transform.position.x;
    }

    private void FixedUpdate()
    {
        if (player.position.x > _minX && player.position.x < maxX)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}