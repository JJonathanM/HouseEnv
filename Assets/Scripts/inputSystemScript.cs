using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputSystemScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Camera main_Camera;

    [Header("Movimiento")]
    [SerializeField] float speed = 2.0f;    
    [SerializeField] float sprintMultiplier = 2.0f;
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference sprint;

    [Header("Detección de Suelo")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] LayerMask groundMask;

    [Header("Salto")]
    [SerializeField] InputActionReference jump;
    [SerializeField] float jumpHeight = 1.2f;
    [SerializeField] float gravity = -9.81f;

    [Header("Mirada")]
    [SerializeField] InputActionReference lookAt;
    [SerializeField] float angle = 85.0f;
    [SerializeField] float lSpeed = 1.8f;

    float cameraRot = 0.0f;
    Vector3 velocity;
    bool isGrounded;
    CharacterController characterC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // GroundCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement
        Vector2 mVector = move.action.ReadValue<Vector2>();        
        Vector3 fMove = (transform.right * mVector.x + transform.forward * mVector.y);
        float currentSpeed = speed;
        if (sprint.action.IsPressed())
        {
            currentSpeed *= sprintMultiplier;
        }
        characterC.Move(fMove * currentSpeed * Time.deltaTime);

        // Jump
        if (jump.action.triggered && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        characterC.Move(velocity * Time.deltaTime);

        // Camera
        Vector2 pan = lookAt.action.ReadValue<Vector2>() * lSpeed * Time.deltaTime;
        transform.Rotate(Vector2.up * pan.x);
        cameraRot -= pan.y;
        cameraRot = Math.Clamp(cameraRot, -angle, angle);
        main_Camera.transform.localEulerAngles = new Vector3(cameraRot, 0f, 0f);
    }
}