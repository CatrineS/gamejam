using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private List<Transform> blobs;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.3f;

    void LateUpdate () {
        Move();

        print("BlobsCount: " + blobs.Count);
	}

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if(blobs.Count == 1)
        {
            return blobs[0].position;
        }

        Bounds bounds = new Bounds(blobs[0].position, Vector3.zero);

        for(int i = 0; i < blobs.Count; i++)
        {
            bounds.Encapsulate(blobs[i].position);
        }

        return bounds.center;
    }


    public void RemoveFromList(Transform blob)
    {
        if(blobs.Count <= 1)
        {
            return;
        }
        else if(blobs.Contains(blob))
        {
            blobs.Remove(blob);
        }
    }
}
