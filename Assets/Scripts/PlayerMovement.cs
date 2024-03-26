using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    public bool Has_Key_1;
    public bool Has_Key_2;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Empêcher la rotation du Rigidbody
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string yAxis = "Mouse Y";
    private void playerMovement(float moveHorizontal, float moveVertical, float jump)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * moveSpeed;
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.deltaTime);

        if (jump > 0 && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Appliquer une force vers le haut pour le saut
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float jump = Input.GetAxis("Jump");
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        if (sprint)
            moveSpeed = 10f;
        else
            moveSpeed = 5f;

        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;
        playerMovement(moveHorizontal, moveVertical, jump);
    }
}
