using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 5.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Empêcher la rotation du Rigidbody
    }

    private void playerMovement(float moveHorizontal, float moveVertical, float jump)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * moveSpeed;
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.deltaTime);

        if (jump > 0 && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Appliquer une force vers le haut pour le saut
        }
    }

    private void playerRotation(float mouseX, float mouseY)
    {
        float rotationX = transform.localEulerAngles.y + mouseX * sensitivity;
        float rotationY = transform.localEulerAngles.x - mouseY * sensitivity;
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float jump = Input.GetAxis("Jump");

        playerMovement(moveHorizontal, moveVertical, jump);
        playerRotation(mouseX, mouseY);
    }
}
