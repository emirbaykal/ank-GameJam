using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   [SerializeField] public int speed=1;
   Rigidbody2D rb;
   void Start () {
      rb = GetComponent<Rigidbody2D>(); 
   }
   void Update () {
 
      float yatay = Input.GetAxis("Horizontal");
      Vector3 hareket = new Vector3(yatay*speed, 0.0f); 
      rb.AddForce(hareket);
   }

   private void OnCollisionStay2D(Collision2D collision)
   {
      if (speed<5)
      {
         if (collision.gameObject.CompareTag("fastGround"))
         {
            speed *= 5;
         }
      }
   }

   private void OnCollisionExit2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("fastGround"))
      {
         rb.velocity=Vector2.zero;
         speed = 1;
      }
   }
}
