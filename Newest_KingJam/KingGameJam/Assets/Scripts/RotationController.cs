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
            RotateObject(Vector3.forward, 8f, -rotX, 0);
        }
        else if (gameObject.tag == "Hexagon")
        {
            RotateObject(Vector3.right, 3f, rotY, 0);
        }
        else if (gameObject.tag == "Star")
        {
            RotateObject(Vector3.up, 10f, -rotX, -rotY);
        }       
    }


    public void RotateObject(Vector3 direction, float speed, float axisOne, float axisTwo)
    {
        rotationSpeed = speed;
        if(axisTwo != 0)
        {      
            transform.RotateAround(direction, axisOne);
            transform.RotateAround(direction, axisTwo);
        }
        else
        {
            transform.RotateAround(direction, axisOne);
        }
    }
}
