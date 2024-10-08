using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        if(target != null)
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
