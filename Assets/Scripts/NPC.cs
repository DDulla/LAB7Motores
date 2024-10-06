using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 3.0f;
    public float maxDistance = 5.0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;
    private bool isStopped = false;
    public float stopDuration = 3.0f; 

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * maxDistance;
    }

    void Update()
    {
        if (isStopped == false) 
        {
            MoveNPC();
        }
    }

    void MoveNPC()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingForward = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Welcome Stranger");
            StartCoroutine(StopAndResumeMovement());
        }
    }

    IEnumerator StopAndResumeMovement()
    {
        isStopped = true;
        yield return new WaitForSeconds(stopDuration);
        isStopped = false;
    }
}


