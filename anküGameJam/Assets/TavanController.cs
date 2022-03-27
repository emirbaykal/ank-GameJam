using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavanController : MonoBehaviour
{
    public bool tavandayim;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tavandayim = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tavandayim = false;
    }
    void Update()
    {
        
    }
}
