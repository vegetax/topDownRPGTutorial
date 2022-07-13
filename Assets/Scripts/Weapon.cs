using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{   
    // Damage of the weapon
     public int[] damage = {1,2,3,4,5,6};
     public float pushForce = 2.0f;
     public Animator animator;
     
     public int weaponId;
     public SpriteRenderer weaponSprite;
    
     //swipe
     public float cooldown = 0.5f;
     public float lastSwing;
     private static readonly int Swing1 = Animator.StringToHash("swing");


     protected override void Start()
     {
         base.Start();
           
         weaponSprite = GetComponent<SpriteRenderer>();
         weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.currentWeaponId];
         
         animator = GetComponent<Animator>();
     }

    
     
     public void UpgradeWeapon()
     {
         if(GameManager.instance.currentWeaponId >=  GameManager.instance.weaponSprites.Count - 1)
         {
             return;
         }
         GameManager.instance.currentWeaponId++;
         weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.currentWeaponId];
         GameManager.instance.weaponImage.sprite = GameManager.instance.weaponSprites[GameManager.instance.currentWeaponId];
     }
     
     
    
     protected override void Update()
     {
         base.Update();
         if (Input.GetKeyDown(KeyCode.Space))
         {
               Swing();
         }
     }
     protected override void OnCollision(Collider2D coll)
     {
         if ( coll.CompareTag("Fighter") && coll.name != "Player")
         {
             Damage dmg = new Damage{
                 damage = damage[GameManager.instance.currentWeaponId],
                 pushForce = pushForce,
                 origin = transform.position,
             };
             coll.SendMessage("ReceiveDamage", dmg);
         }
         
     }
    
     public void Swing()
     {
         if (Time.time > lastSwing + cooldown)
         {
             
             lastSwing = Time.time;
             animator.SetTrigger(Swing1);
             Debug.Log("Swing");
         }
     }
    
}
