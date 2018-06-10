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
    public Animator anim; 


    public enum BlobState { Alive, Dead, InGoal }
    public BlobState state;


    public delegate void BlobDelegate(BlobAgent agentScript);
    public BlobDelegate blobSaved;
    public BlobDelegate blobDied;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        state = BlobState.Alive;
    }

    void Update() {

        transform.LookAt(positions[positionIndex].position);
        rb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);
  
        if (jumping || moveSpeed > 3)
        {
            jumping = false;
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
            anim.Play("Idle");
        }

        if (moveSpeed <= 3f)
        {
            anim.Play("Walking");
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
            state = BlobState.Dead;
            RemoveFromList();
            gameObject.SetActive(false);

            if(blobDied != null)
                blobDied(this);

        }
        if (other.tag == "WinningTrigger"){
            state = BlobState.InGoal;
            Invoke("DisableRigidBody", UnityEngine.Random.Range(0.4f, 1f));      
            if (blobSaved != null)
                blobSaved(this);
        }
    }


    private void DisableRigidBody()
    {
        rb.isKinematic = true;
    }


}
  //transform.position = Vector3.MoveTowards(transform.position, positions[0].position, 2f * Time.deltaTime);
  //  transform.Translate(Vector3.forward * 5f * Time.deltaTime);