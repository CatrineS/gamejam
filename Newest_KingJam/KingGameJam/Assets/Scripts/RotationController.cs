using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{

    float rotationSpeed = 8;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        if (gameObject.tag == "Cube")
        {
            transform.RotateAround(Vector3.forward, -rotX);
        }
        else if (gameObject.tag == "Hexagon")
        {

        }
        else if (gameObject.tag == "Star")
        {
            transform.RotateAround(Vector3.up, rotY);
        }
        
    }
}
