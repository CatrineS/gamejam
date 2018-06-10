using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonTwirl : MonoBehaviour
{
    private Vector3 screenPoint;
    private float rotationSpeed = 5f;

    private void OnMouseDrag()
    {
        float mouseXInput = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float mouseYInput = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        if (gameObject.tag == "playButton")
        {
            //transform.RotateAround(Vector3.forward, mouseYInput);
            transform.RotateAround(Vector3.forward, mouseXInput);
            Invoke("StartScene", 1.5f);
        }
    }

    void StartScene()
    {

        SceneChange.instance.changeScene(1);
    }
}
