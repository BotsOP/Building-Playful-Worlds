﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float sprintIncrease;
    public float jumpForce;
    public float raycastDistance;
    bool shouldIncrease = true;
    public Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    public Vector3 standScale = new Vector3(1, 1, 1);

    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
        Sprint();
        //Crouch();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPos);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            Debug.Log(shouldIncrease);
            if(shouldIncrease) {
                Debug.Log("test");
                speed += sprintIncrease;
                shouldIncrease = false;
            }    
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && speed > sprintIncrease || Input.GetKeyUp(KeyCode.W) && speed > sprintIncrease )
        {
            speed -= sprintIncrease;
            shouldIncrease = true;
        }
    }

    //private void Crouch()
    //{
    //    Vector3 newScale;
        
        
    //    if (Input.GetKey(KeyCode.LeftControl))
    //    {
    //        speed = 1;
    //        newScale = crouchScale;
    //        transform.localScale = newScale;
    //    }
    //    if (Input.GetKeyUp(KeyCode.LeftControl))
    //    {
    //        speed = 3;
    //        newScale = standScale;
    //        transform.localScale = newScale;
    //    }
    //}

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.blue);
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance); ;
    }

    
}
