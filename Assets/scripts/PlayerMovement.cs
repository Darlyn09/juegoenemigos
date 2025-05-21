using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f; // ← Aumentado para caminar más rápido
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float jumpHeight = 1.5f; // ← Nueva variable de salto

 
    void Start()
    {
            controller = GetComponent<CharacterController>();

            if (controller == null)
                Debug.LogError("FALTA el CharacterController en " + gameObject.name);
    }
 

    void Update()
    {
        // --- CHEQUEO DE SUELO ---
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // --- INPUT MOVIMIENTO ---
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveDir = Vector3.zero;

        if (inputDirection.magnitude >= 0.1f)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            moveDir = (camForward * inputDirection.z + camRight * inputDirection.x).normalized;

            // Rotación suave
            float rotationSpeed = 5f; // ← Más lento
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // --- SALTO ---
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- GRAVEDAD ---
        velocity.y += gravity * Time.deltaTime;

        // --- MOVIMIENTO TOTAL ---
        Vector3 finalMove = moveDir * speed;
        finalMove.y = velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }


    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }

}

