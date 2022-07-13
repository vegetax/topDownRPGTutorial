using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Mover
{
    public  int xp = 1;
    private bool findedPlayer = false;
    private float chaseRange = 1.6f; 
    private float warnningRange = 0.8f;
    private bool collidingWithPlayer = false;
    private BoxCollider2D hitbox;
    public ContactFilter2D contactFilter;
    private Collider2D[] hitColliders = new Collider2D[10];
    
    public float speed = 0.5f;
    
    
    private Vector3 playerPosition;
    private Vector3 startPosition;
    
    
    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
        hitbox = GetComponentsInChildren( typeof( BoxCollider2D ) )[0] as BoxCollider2D;
    }

    private void FixedUpdate()
    {
        playerPosition = GameManager.instance.player.transform.position;
        findedPlayer =  Vector3.Distance(playerPosition , transform.position) < warnningRange;

       
        if (findedPlayer)
        {
            if ( Vector3.Distance(playerPosition,transform.position) < chaseRange )
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerPosition-transform.position).normalized * speed);
                }
            }
        }
        else
        {
            findedPlayer = false;
            if (Vector3.Distance(startPosition,transform.position) > 0.1f )
            {
                UpdateMotor((startPosition-transform.position).normalized* speed );
            }
        }
        
        collidingWithPlayer = false;
        _boxCollider.OverlapCollider(contactFilter, hitColliders);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i] == null)
                continue; 
            if(hitColliders[i].name == "Player")
            {
                collidingWithPlayer = true;
                Debug.Log("enemy collid " + hitColliders[i].name); 
            }
            hitColliders[i] = null;
        }
       

    }

    protected override void Death()
    {
        base.Death();
        GameManager.instance.xp += xp;
        GameManager.instance.showFloatingText("+ "+xp+" xp", transform.position ,Vector3.up*50,25 , Color.yellow , 3.0f);
    }
}
