using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPositionScript : MonoBehaviour {

    public Transform positionParent;
    public List<Transform> positionTransforms;
    public Transform currentDestination;

    int currentIndex = 0;

	// Use this for initialization
	void Start () {
		foreach(Transform child in positionParent)
        {
            positionTransforms.Add(child);
        }
	}
	
    public void TriggerNextPosition()
    {
        currentDestination = positionTransforms[currentIndex];
        currentIndex++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PositionTrigger")
        {
            TriggerNextPosition();
        }
    }

}
