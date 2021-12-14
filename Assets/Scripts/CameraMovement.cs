using System.Collections;
using UnityEngine;

namespace Assets.Noneuclid.Scripts
{
    public class CameraMovement : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {

			float dt = Time.deltaTime;

			float rotateSpeed = 2.0f;
			float mx = Input.GetAxis("Mouse X");
			transform.RotateAround(Vector3.up, dt * rotateSpeed * mx);
			Vector3 rightVector = transform.rotation * Vector3.right;
			float my = Input.GetAxis("Mouse Y");
			transform.RotateAround(rightVector, -dt * rotateSpeed * my);
		}
    }
}