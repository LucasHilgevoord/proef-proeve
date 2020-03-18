using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    private Vector3 offset;
    private float followSpeed = 1f;

    void Start()
    {
        offset = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 newPos = Vector3.Lerp(transform.position, desiredPos, followSpeed);
        transform.position = newPos;
    }
}
