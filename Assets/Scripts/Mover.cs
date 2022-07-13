using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Mover : Fighter
{
    protected BoxCollider2D _boxCollider;
    protected Vector3 _moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1f ;

    protected virtual  void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    
    
    protected virtual void UpdateMotor(Vector3 input)
    {
        //reset move delta
        _moveDelta = input;
        //swipe direction 
        if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }
        //push movement
        _moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);
         
        //make sure player can move in the direction y
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y), Mathf.Abs(_moveDelta.y*Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));
        
        if (hit.collider == null) 
        {
            transform.Translate(0,_moveDelta.y * Time.deltaTime,0); 
        }
        //make sure player can move in the direction x
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0), Mathf.Abs(_moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(_moveDelta.x * Time.deltaTime,0,0); 
        }
    }
}
