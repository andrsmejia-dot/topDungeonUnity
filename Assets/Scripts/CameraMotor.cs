using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    private void
        LateUpdate() //This LateUpdate is called after update and FixedUpdate, because we want the object to move later, not instantly with the character movement.
    {
            //Difference between 2 frames
        Vector2 delta = Vector2.zero;
        
        //This is to check if we're inside the bounds on the X axis
            //Distance between the player and the focus point of the camera
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) //To know if the player is outside the bounds of the camera
        {
                //To know witch side is (Left or Right)
            if (transform.position.x < lookAt.position.x) //If the center of the camera is smaller than the player, it means that the player is on the right and the focus left
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        
        //Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) //To know if the player is outside the bounds of the camera
        {
            //To know witch side is (Left or Right)
            if (transform.position.y < lookAt.position.y) //If the center of the camera is smaller than the player, it means that the player is on the right and the focus left
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        
            //Moving the camera
            transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

