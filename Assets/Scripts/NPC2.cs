using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public float speed = 3.0f;
    public float stopDistance = 2.0f;
    public Transform player; 

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            Debug.Log("El segundo es el primero de los perdedores ~Ayrton Senna~");
        }
    }
}

