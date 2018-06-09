using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform BlobParent;
    [SerializeField] private List<Transform> blobs;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.3f;

    private void Awake()
    {
        foreach(Transform child in BlobParent)
        {
            blobs.Add(child);
        }
    }

    void LateUpdate () {
        Move();
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
            bounds.Encapsulate(blobs[i].localPosition);
        }

        return new Vector3(transform.position.x, transform.position.y, bounds.center.z);
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
