using System.Collections;
using UnityEngine;

namespace Assets.Noneuclid.Scripts
{
    public class CameraMovement : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
			float moveSpeed = 10;
			float dt = Time.deltaTime;
			Vector3 move = new Vector3(0, 0, 0);
			if (Input.GetAxis("Horizontal") < 0)
			{
				move = move + new Vector3(-1, 0, 0);
			}
			else if (Input.GetAxis("Horizontal") > 0)
			{
				move = move + new Vector3(1, 0, 0);
			}
			if (Input.GetAxis("Vertical") > 0)
			{
				move = move + new Vector3(0, 0, 1);
			}
			else if (Input.GetAxis("Vertical") < 0)
			{
				move = move + new Vector3(0, 0, -1);
			}
			move.Normalize();
			transform.Translate(move * dt * moveSpeed);

			float rotateSpeed = 2.0f;
			float mx = Input.GetAxis("Mouse X");
			transform.RotateAround(Vector3.up, dt * rotateSpeed * mx);
			Vector3 rightVector = transform.rotation * Vector3.right;
			float my = Input.GetAxis("Mouse Y");
			transform.RotateAround(rightVector, -dt * rotateSpeed * my);
		}
    }
}