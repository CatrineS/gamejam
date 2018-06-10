using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Restarter))]
public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform BlobParent;
    [SerializeField] private Transform ZoomedInTransform;
    [SerializeField] private Transform ZoomedOutTransform;

    [SerializeField] private List<Transform> blobs;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.3f;


private float camZoomInY = -2f, camRotationX = 15f;
    private bool zoomingIn = false;
    private bool zoomingOut = false;

    private Score scoreSystem;

    private void Awake()
    {
        scoreSystem = GetComponent<Score>();
        foreach(Transform child in BlobParent)
        {
            blobs.Add(child);
        }

        GetComponent<Restarter>().SetBlobList(blobs);
    }


    void LateUpdate () {
        if(blobs.Count > 0)
        {
            Move();
            Zoom();
        }
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private void Zoom()
    {
        float shouldZoom = GreatestDistance();
        if(shouldZoom < 10 && !zoomingIn)
        {



        }
     
        if (zoomingIn)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, camZoomInY, 0), 1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-15f, 0, 0)), 1f);
        }
        else if (zoomingOut)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, -camZoomInY, 0), 1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(15f, 0, 0)), 1f);
        }
    }

    private float GreatestDistance()
    {
        Bounds bounds = new Bounds(blobs[0].position, Vector3.zero);

        for (int i = 0; i < blobs.Count; i++)
        {
            bounds.Encapsulate(blobs[i].localPosition);
        }
        return bounds.size.z;
    }

    Vector3 GetCenterPoint()
    {
        Bounds bounds = new Bounds(blobs[0].position, Vector3.zero);

        for(int i = 0; i < blobs.Count; i++)
        {
            bounds.Encapsulate(blobs[i].localPosition);
        }

        return new Vector3(transform.position.x, transform.position.y, bounds.center.z);
    }


    public void RemoveFromList(Transform blob)
    {
        if(blobs.Count < 1)
        {
            blobs.Clear();
            scoreSystem.UpdateScore();
            return;
        }
        else if(blobs.Contains(blob))
        {
            blobs.Remove(blob);
            scoreSystem.UpdateScore();
        }
    }


    public int BlobsSize()
    {
        return blobs.Count;
    }
}
