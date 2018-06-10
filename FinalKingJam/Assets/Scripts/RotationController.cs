using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private float rotationSpeed = 5f;

    private enum ObjectType { Cube, Hexagon, Star }
    private ObjectType type;

    private void Awake()
    {
        SetType();    
    }

    private void OnMouseDrag()
    {
        float mouseXInput = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float mouseYInput = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        if (type == ObjectType.Cube)
        {
            RotateObject(Vector3.forward, 8f, -mouseXInput, 0);
        }
        else if (type == ObjectType.Hexagon)
        {
            RotateObject(Vector3.right, 3f, mouseYInput, 0);
        }
        else if (type == ObjectType.Star)
        {
            RotateObject(Vector3.up, 5f, -mouseXInput, -mouseYInput);
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

    private void SetType()
    {
        if (gameObject.tag == "Cube")
        {
            type = ObjectType.Cube;
        }
        else if (gameObject.tag == "Hexagon")
        {
            type = ObjectType.Hexagon;
        }
        else if (gameObject.tag == "Star")
        {
            type = ObjectType.Star;
        }
    }

}
/*   private void TestRotate(Vector3 rotateAround, float rotX, float rotY)
   {
       selectedObject.transform.Rotate(rotateAround, rotX);
   } */
