using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoints = 10;
    public int maxHitPoints = 10;
    public float pushRecoverySpeed = 0.2f;
    
    protected float immuneTime = 1.0f;
    protected float lastImmune;
    
    //push
    protected Vector3 pushDirection;
    
    protected  virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoints -= dmg.damage;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce; 
            GameManager.instance.showFloatingText(dmg.damage.ToString(), transform.position ,Vector3.up*50,20 , Color.red , 2.0f);
        }

        if (hitPoints <= 0)
        {
            hitPoints = 0;
              Death();
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
     


}
