using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public GameObject leverPlatform;
    public GameObject door;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            leverPlatform.transform.position = new Vector2(leverPlatform.transform.position.x,
                (leverPlatform.transform.position.y) - 0.2f);
            door.transform.position = new Vector2(door.transform.position.x, (door.transform.position.y) + 0.1f);
        }
    }
}
