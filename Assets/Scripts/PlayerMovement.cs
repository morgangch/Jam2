using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Exemple de script pour le mouvement du joueur
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 5.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotation horizontale du joueur (et de la caméra)
        transform.Rotate(Vector3.up, mouseX);

        // Rotation verticale de la caméra (limitée entre -90 et 90 degrés)
        float rotationX = -mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);

        // Mouvement du joueur
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.fixedDeltaTime);
    }
}
