using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Vector3 _moveDelta;
    public  float speed = 2f;
    private RaycastHit2D hit;


    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _moveDelta = new Vector3(x, y, 0);

        //swipe direction 
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, _moveDelta, 0.05f,
            LayerMask.GetMask("Actor", "Blocking"));
        ; 
        if (hit.collider == null)
        {
            // make thing move  
            transform.Translate(_moveDelta * Time.deltaTime * speed);
        }
        
    }
}
