using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public bool bitti = true;
    Animator animator;
    public characterMechs cmechs;
    private float nextActionTime = 0.0f;
    private float period = 1f;
    bool dirRight;
    Vector3 nextScale;
    public float scaleDecrease,totalScaleDecrease;
    // Start is called before the first frame update
    void Start()
    {
        cmechs = GameObject.Find("slime").GetComponent<characterMechs>();
        nextScale = transform.localScale;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cmechs.movX > 0)
        {
            dirRight = true;
            nextScale = new Vector3((transform.localScale.x),transform.localScale.y,transform.localScale.z);
            if (nextScale.x < 0)
            {
                nextScale.x = -(nextScale.x);
            }
        }
        else if (cmechs.movX < 0)
        {
            dirRight = false;
            nextScale = new Vector3(-(transform.localScale.x),transform.localScale.y,transform.localScale.z);
            if (nextScale.x > 0)
            {
                nextScale.x = -(nextScale.x);
            }
        }
        transform.localScale = nextScale;
        //Debug.Log(nextScale);

        if (cmechs.movX != 0)
        {
            if (Time.time > nextActionTime ) 
            {
                nextActionTime += period;
                //changedScale = new Vector3(nextScale.x - totalScaleDecrease, nextScale.y- totalScaleDecrease, nextScale.z-totalScaleDecrease);
                
                if (dirRight == true)
                {
                    transform.localScale = new Vector3(transform.localScale.x - scaleDecrease,transform.localScale.y - scaleDecrease,transform.localScale.z - scaleDecrease);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x + scaleDecrease,transform.localScale.y - scaleDecrease,transform.localScale.z - scaleDecrease);
                }
            }
        }
    }
}
