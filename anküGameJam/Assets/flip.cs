using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public characterMechs cmechs;
    private Vector3 currentScale;
    // Start is called before the first frame update
    void Start()
    {
        cmechs = GameObject.Find("slime").GetComponent<characterMechs>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            scale.x = -5;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            scale.x = 5;
        }
        transform.localScale = scale;
        /*if (cmechs.yatay == true)
        {
            if (cmechs.movX < 0)
            {
                currentScale = transform.localScale;
                transform.localScale = new Vector3(currentScale.x,transform.localScale.y,transform.localScale.z);
            }
            if (cmechs.movX > 0)
            {
                currentScale = transform.localScale;
                transform.localScale = new Vector3(-currentScale.x,transform.localScale.y,transform.localScale.z);
            }
        }*/
    }
}
