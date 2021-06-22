using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed;
    public float smoothTurnTime = 0.1f;
    public float gravity = 5f; //Needed in case of adding a jump

    private Camera cam;
    private float turnSmoothVelocity;
    private Vector3 moveDirection = Vector3.zero;

    [HideInInspector]
    public bool activeMovement = true; //Use for deactivate PlayerMovement


    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        if(activeMovement)
            MoveCharacter();
    }
    
    private void MoveCharacter() // This is only the WASD movement, the camera movement come from the freeLook Cinemacine camera
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        if(moveDirection.magnitude >= 0.1f)
        {
            float rotAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, rotAngle, 0f) * Vector3.forward;
            moveDir.y -= gravity;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
    }
}
