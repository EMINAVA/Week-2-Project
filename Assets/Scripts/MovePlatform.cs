using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public bool moveSideToSide;
    public bool moveFrontToBack;
    public bool moveUpAndDown;
    public float moveTime;
    public float sideToSideSpeed;
    public float frontToBackSpeed;
    public float upAndDownSpeed;

    private float currentTime;
    private bool moving = false;
    protected virtual void Start()
    {
        moving = true;
        currentTime = moveTime;
        // Added line to translate the movement so that the center is the place where the GameObject is originally located
        transform.Translate(
            frontToBackSpeed * moveTime / -2f,
            upAndDownSpeed * moveTime / -2f,
            sideToSideSpeed * moveTime / -2f
        );
    }

    // Moved logic to FixedUpdate
    private void FixedUpdate()
    {
        if (!moving) return;
        if (currentTime <= 0)
        {
            sideToSideSpeed *= -1; // Change direction!
            frontToBackSpeed *= -1;
            upAndDownSpeed *= -1;
            currentTime = moveTime;
        }
        
        Move();
    }
    
    private void Update()
    {
        if (moving)
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if(moveSideToSide)
        {
            transform.Translate(Vector3.forward * sideToSideSpeed * Time.deltaTime);
        }

        if(moveFrontToBack)
        {
            transform.Translate(Vector3.right * frontToBackSpeed * Time.deltaTime);
        }

        if(moveUpAndDown)
        {
            transform.Translate(Vector3.up * upAndDownSpeed * Time.deltaTime);
        }
    }
}