using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    public bool isCollected = false;
    protected override void OnCollision(Collider2D coll)
    {
        if (coll.name == "Player" && !isCollected)
        {
            OnCollect();
        }
    }
    
    protected virtual  void OnCollect()
    {
        isCollected= true;
    }
}
