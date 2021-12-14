using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInteract : MonoBehaviour
{
    public Transform interactIndicator;
    private Transform indicatorObject;

    private GameObject mirror;

    void Update()
    {
        if (mirror != null)
        {
            Interact(mirror);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        mirror = other.gameObject;
        if (other.tag == "Mirror")
        {
            ShowIndicator(mirror.transform.position + Vector3.up);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (indicatorObject != null)
        {
            Destroy(indicatorObject.gameObject);
        }
        if (mirror != null)
        {
            mirror = null;
        }
    }

    private void Interact(GameObject interactable) {
        if (Input.GetMouseButton(0))
        {
            float dt = Time.deltaTime;
            float rotateSpeed = 2.0f;
            float mx = Input.GetAxis("Mouse X");
            interactable.transform.RotateAround(Vector3.up, dt * rotateSpeed * mx);
        }

    }

    private void ShowIndicator(Vector3 position)
    {
        indicatorObject = GameObject.Instantiate(interactIndicator);
        indicatorObject.position = position;
    }

}
