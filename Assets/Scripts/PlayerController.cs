using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
	public GameObject player;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 4f;
    public float gravity = 10f;


    public float lookSpeed = 2.5f;
    public float lookXLimit = 70f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    
    CharacterController characterController;
    void Start()
    {
        if (PlayerPrefs.HasKey("walkSpeed")) {
            walkSpeed = PlayerPrefs.GetFloat("walkSpeed");
        }
        if (PlayerPrefs.HasKey("sprintSpeed")) {
            runSpeed = PlayerPrefs.GetFloat("sprintSpeed");
        }
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
		if (PlayerPrefs.GetInt("gameIsPaused") == 1) {
			canMove = false;
		} else {
			canMove = true;
		}
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
		bool isCrouching = Input.GetKey(KeyCode.LeftControl);
		if (isCrouching) {
			isRunning = false;
			player.transform.localScale = new Vector3(1, 0.8f, 1);
		} else {
			player.transform.localScale = new Vector3(1, 1.3f, 1);
		}
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
}