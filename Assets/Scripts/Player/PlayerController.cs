using System;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movement;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 3f;
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate(){
        HandleMovement();
    }


    public void Move(InputAction.CallbackContext context){
        movement = context.ReadValue<Vector2>();

    }
    private void HandleMovement()
    {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(movement.x,0f,movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.deltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x,-xClamp,xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z,-zClamp,zClamp);
        rb.MovePosition(newPosition);
    }
}
