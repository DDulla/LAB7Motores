using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody movementP;
    private BoxCollider boxCollider;
    [SerializeField] private float velocity;
    [SerializeField] private Vector3 direction;

    private void Awake()
    {
        movementP = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
    public void movementDirection(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(direction.x * velocity, movementP.velocity.y, direction.y * velocity);
        movementP.velocity = movement;
    }
}
