using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{ 
   public Transform lookAt;
   public float boundx = 0.5f;
   public float boundy = 0.5f;
//
   private void LateUpdate()
   {
        Vector3 Delta = Vector3.zero;
        float deltaX = lookAt.position.x - transform.position.x;
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaX > boundx )
        {
             transform.position = new Vector3(transform.position.x + deltaX - boundx, transform.position.y, transform.position.z);
            
        }else if (deltaX < -boundx)
        {
            transform.position = new Vector3(transform.position.x + deltaX + boundx, transform.position.y, transform.position.z);
        }
        if (deltaY > boundy)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + deltaY - boundy, transform.position.z);
        }
        else if (deltaY < -boundy)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + deltaY + boundy, transform.position.z);
        }
       
   }
}
