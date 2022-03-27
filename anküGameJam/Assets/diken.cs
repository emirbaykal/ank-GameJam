using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diken : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("karakter öldü");
        }
    }
}
