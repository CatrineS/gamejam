using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonTwirl : MonoBehaviour
{
    private Vector3 screenPoint;
    private float rotationSpeed = 5f;
    private int counter = 0;
    public Text helpText;


    private void OnMouseDrag()
    {
        
        float mouseXInput = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float mouseYInput = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        if (gameObject.tag == "playButton")
        {
            //transform.RotateAround(Vector3.forward, mouseYInput);

        
            transform.RotateAround(Vector3.forward, mouseXInput);

            Invoke("StartScene", 2f);
        }
    }

    void StartScene()
    {

        SceneChange.instance.changeScene(1);
    }
    private void OnMouseDown()
    {
        counter++;
   
        if (counter >= 2)
        {
            helpText.gameObject.SetActive(true);
        }
    }

}
