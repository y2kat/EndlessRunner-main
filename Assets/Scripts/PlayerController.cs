using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce;
    private Vector3 targetPosition;
    [SerializeField] float laneDistance = .1f;
    [SerializeField] float laneChangeSpeed = .1f;
    [SerializeField] float speed = 5f;
    [SerializeField] float acceleration = 0.1f;

    private PlayerActions playerActions;
    private Rigidbody rb;
    public float distanceTravelled = 0f; 
    private Vector3 lastPosition;
    private float distanceMarker = 100f;

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.Enable();
    }

    void Start()
    {
        playerActions.Standard.Jump.performed += Jump;
        playerActions.Standard.Left.performed += Left;
        playerActions.Standard.Right.performed += Right;
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        lastPosition = transform.position;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }

    private void Left(InputAction.CallbackContext context)
    {
        targetPosition.x -= laneDistance;
    }

    private void Right(InputAction.CallbackContext context)
    {
        targetPosition.x += laneDistance;
    }

    void Update()
    {
        Vector3 newX = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneChangeSpeed);
        transform.position = newX;
        lastPosition = transform.position;
        distanceTravelled += speed * Time.deltaTime;
        if (distanceTravelled >= distanceMarker)
        {
            speed += acceleration;
            distanceMarker += 100f;
        }
    }
}