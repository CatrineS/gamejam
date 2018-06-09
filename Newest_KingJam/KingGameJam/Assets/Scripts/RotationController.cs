using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{

    float rotationSpeed = 5f;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        if (gameObject.tag == "Cube")
        {
            rotationSpeed = 8f;
            transform.RotateAround(Vector3.forward, -rotX);
        }
        else if (gameObject.tag == "Hexagon")
        {
            rotationSpeed = 3f;
            transform.RotateAround(Vector3.right, rotY);
        }
        else if (gameObject.tag == "Star")
        {
            rotationSpeed = 10f;
            transform.RotateAround(Vector3.up, -rotX);
            transform.RotateAround(Vector3.up, -rotY);
        }
        
    }
}
