using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloor : MonoBehaviour {

    bool turning = false; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            turning = !turning;
        }
        if (turning)
        {
            TurnFloor();
        }
    }


    void TurnFloor(){
        transform.Rotate(Vector3.forward * Time.deltaTime);
    }



}
