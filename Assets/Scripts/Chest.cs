using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable

{
    public Sprite hasCollected;
    public int gems = 0;
     protected override void OnCollect( )
     {
         isCollected = true;
         GetComponent<SpriteRenderer>().sprite = hasCollected; 
         GameManager.instance.gems += gems;
         GameManager.instance.showFloatingText("string msg", transform.position ,Vector3.up*50,25 , Color.yellow , 3.0f);
         Debug.Log("Player collected " + gems + " gems");
     }
}
