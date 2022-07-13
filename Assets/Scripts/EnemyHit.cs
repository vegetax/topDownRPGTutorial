using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Collidable
{
      // Damage of the weapon
          public int damage = 1;
          public float pushForce = 2.0f;
         
         
         
          //swipe
          public float cooldown = 0.5f;
          public float lastAttack  = 0.0f;
         
           
          protected override void OnCollision(Collider2D coll)
          {
              if (!coll.CompareTag("Fighter") || coll.name != "Player") return;
              if(Time.time > lastAttack + cooldown)
              {
                  Damage dmg = new Damage{
                      damage = damage, 
                      pushForce = pushForce,
                      origin = transform.position,
                  };
                  coll.SendMessage("ReceiveDamage", dmg);  
              }

          } 
         
       
}
