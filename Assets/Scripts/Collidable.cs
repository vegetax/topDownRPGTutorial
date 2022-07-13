using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D contactFilter;
    private Collider2D[] hitColliders = new Collider2D[10];
    private BoxCollider2D boxCollider;

    protected virtual void Start()
    {
       boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
       //collision work
       boxCollider.OverlapCollider(contactFilter, hitColliders);
         for (int i = 0; i < hitColliders.Length; i++)
         {
              if (hitColliders[i] == null)
                  continue; 
              OnCollision(hitColliders[i]);
              hitColliders[i] = null;
         }
        
    }

    protected virtual void OnCollision(Collider2D coll)
    {   
        Debug.Log("not implemented Collision with " + coll.name);
    }

}
