using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class BlobAgent : MonoBehaviour {



    [SerializeField] private Transform[] positions;
    [SerializeField] private Vector3 jumpDirection = new Vector3(0, 1f, 0);
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool jumping = false;
    [SerializeField] private float moveSpeed = 3f;
    private int positionIndex = 0;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        transform.LookAt(positions[positionIndex].position);
        rb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);
  
        if (jumping)
        {
            jumping = false;
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
        }
    }

    private void JumpTrigger()
    {
        jumping = true;
    }


    private void TriggerNextPosition()
    {
        positionIndex++;
    }

    private void RemoveFromList()
    {
        FindObjectOfType<CameraFollow>().RemoveFromList(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpingPad")
        {
            JumpTrigger();
        }

        if (other.tag == "PositionTrigger")
        {
            TriggerNextPosition();
        }

        if (other.tag == "DeathZone")
        {
            RemoveFromList();
            gameObject.SetActive(false);
        }
        if (other.tag == "WinningTrigger"){
            rb.isKinematic = true;
        }
    }


}
  //transform.position = Vector3.MoveTowards(transform.position, positions[0].position, 2f * Time.deltaTime);
  //  transform.Translate(Vector3.forward * 5f * Time.deltaTime);