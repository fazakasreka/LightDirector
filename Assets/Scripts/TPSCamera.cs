using UnityEngine;
using System.Collections;

public class TPSCamera : MonoBehaviour {
	public Transform target;
	public float cameraHeight = 3.0f;
	public float targetHeight = 1.6f;
	public float camDistance = 3.0f;
	public float smoothness = 0.5f;

	Transform targetTransform;
	Transform cameraTransform;
	void Start () {
		targetTransform = target.transform;
		cameraTransform = transform;
	}
	
	void Update () {
		if (Input.GetMouseButton(1))
		{
			float mouseY = Input.GetAxis("Mouse Y");
			if (cameraHeight + mouseY > 0 && cameraHeight + mouseY < 20)
				cameraHeight += mouseY;
		}
		float mouseScroll = Input.GetAxis ("Mouse ScrollWheel");
		camDistance += mouseScroll;

		Vector3 targetDir = targetTransform.forward;
		Vector3 oldCamPos = cameraTransform.position;
		Vector3 newCamPos = targetTransform.position 
			- targetDir * camDistance + new Vector3 (0, cameraHeight, 0);
		Vector3 targetPos = targetTransform.position + new Vector3 (0, targetHeight, 0);
		newCamPos = Vector3.Lerp (newCamPos, oldCamPos, smoothness);
		cameraTransform.position = newCamPos;
		cameraTransform.LookAt(targetPos);
	}
}
