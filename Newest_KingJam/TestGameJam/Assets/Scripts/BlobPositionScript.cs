using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPositionScript : MonoBehaviour {

    public List<Transform> positionTransforms;

    public Transform positionParent;
    public Transform currentDestination;

    [SerializeField] private float triggerDistance = 10f;

    int currentIndex = 0;

	// Use this for initialization
	void Start () {
		foreach(Transform child in positionParent)
        {
            positionTransforms.Add(child);
        }

        currentDestination = positionTransforms[0];
	}


    private void Update()
    {
        transform.LookAt(positionTransforms[currentIndex]);

        float distanceToNextPoint = Vector3.Distance(transform.localPosition, positionTransforms[currentIndex].localPosition);


        if(distanceToNextPoint < triggerDistance)
        {
            TriggerNextPosition();
        }
    }

    public void TriggerNextPosition()
    {
        currentDestination = positionTransforms[currentIndex++];
    }

    public Vector3 GetCurrentDestination()
    {
        return currentDestination.position;
    }

}
