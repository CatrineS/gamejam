using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlobAgent : MonoBehaviour {

    NavMeshAgent blobAgent;


    [SerializeField] private Transform[] positions;
    private int currentIndex = 0;


    private void Awake()
    {
        blobAgent = GetComponent<NavMeshAgent>();
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            blobAgent.SetDestination(positions[0].position);
        }
	}
}
