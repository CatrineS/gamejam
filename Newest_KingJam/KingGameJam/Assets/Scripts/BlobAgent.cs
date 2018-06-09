using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlobAgent : MonoBehaviour {

    [SerializeField] private Transform[] positions;


    void Update() {
        transform.LookAt(positions[0].position);
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }
}
