using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxColider;
    private Vector3 _moveDelta; //Better for player movement, more precise
    private RaycastHit2D _hit;
    
    private void Start()
    {
            //This is for collision detection
        _boxColider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() //Better for physics, not for inputs
    {
        float x = Input.GetAxisRaw("Horizontal"); //This return 1, -1 or 0
        float y = Input.GetAxisRaw("Vertical");
        
            //Reset moveDelta
        _moveDelta = new Vector3(x, y, 0);
        
            //Swap sprite direction, wether you´re going right or left
        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Collision
            //Here we're making sure that we can move in this direction, by casting a box there first, if the box returns null, we´re free to move.
                // Y Axes
        _hit = Physics2D.BoxCast(transform.position, _boxColider.size, 0, new Vector2(0, _moveDelta.y),
            Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider == null)
        {
                    //Make the sprite move
            transform.Translate(0,_moveDelta.y*Time.deltaTime,0); //Time.deltaTime is to make the game run equals in all devices (speed)
        }
                // X Axes
        _hit = Physics2D.BoxCast(transform.position, _boxColider.size, 0, new Vector2(_moveDelta.x,0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider == null)
        {
                    //Make the sprite move
            transform.Translate(_moveDelta.x*Time.deltaTime,0,0); //Time.deltaTime is to make the game run equals in all devices (speed)
        }
        
    }
}
