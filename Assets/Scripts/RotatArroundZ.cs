using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatArroundZ : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        var rotateSpeed = 0.1f;
        transform.RotateAround(Vector3.forward, dt * rotateSpeed);
    }
}
