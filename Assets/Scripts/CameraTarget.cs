using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    void FixedUpdate() {
        // don't think this is right
        transform.position = target.position - transform.position * (Time.fixedDeltaTime * speed);
    }
}
