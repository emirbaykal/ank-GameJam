using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterMechs : MonoBehaviour
{
    flip flip;
    public bool yatay;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float moveSpeed;
    public Vector3 direction;
    Rigidbody2D rb;
    Quaternion rotation;
    float distanceX, distanceY;
    bool uzerinde;
    public GameObject izler;
    public GameObject iz;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    Vector3 izLocation;
    Vector3 contactObject;
    public float movX;
    public float dashForce;
    public float startDashTimer;
    float currentDashTimer;
    float dashDirection;
    bool isDashing;
    float slimeLoc;
    public int orantiSabiti;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 startingPos = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flip = GetComponent<flip>();
    }

    void Update()
    {
        hareket();
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            isDashing = true;
            currentDashTimer = startDashTimer;
            rb.velocity = Vector2.zero;
            dashDirection = (int)movX;
        }
        if (isDashing)
        {
            rb.velocity = transform.right * dashDirection * dashForce;
            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer <= 0)
            {
                animator.SetTrigger("dash");
                isDashing = false; 
            }
        }
    }
    void hareket()
    {
        movX=Input.GetAxis("Horizontal");
        
        
        
            transform.Translate(direction * movX * Time.deltaTime * moveSpeed);
        
        
        if (movX != 0)
        {
            animator.SetBool("isWalk",true);
        }
        else
        {
            animator.SetBool("isWalk",false);
        }
        if (Time.time > nextActionTime && Input.GetAxis("Horizontal") != 0) 
        {
            nextActionTime += period;
            Instantiate(iz,new Vector3(contactObject.x + distanceX , contactObject.y + distanceY, 0), rotation,izler.transform);
            //transform.localScale = new Vector3(transform.localScale.x+totalScaleDecrease,transform.localScale.y+totalScaleDecrease,transform.localScale.z+totalScaleDecrease);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "left")
        {
            Vector3 startingPos = transform.position;
            direction = -Vector3.up;
            rb.gravityScale = 1;
            rotation = Quaternion.Euler(0, 0, -90);
            animator.SetFloat("yurumeBlend",2);
            yatay = false;
        }
        else if(other.gameObject.tag == "right")
        {
            Vector3 startingPos = transform.position;
            direction = Vector3.up;
            rb.gravityScale = 1;
            rotation = Quaternion.Euler(0, 0, 90);
            animator.SetFloat("yurumeBlend",2);
            yatay = false;
        }
        else if(other.gameObject.tag == "bottom")
        {
            Vector3 startingPos = transform.position;
            direction = Vector3.right;
            rotation = Quaternion.Euler(0, 0, 0);
            animator.SetFloat("yurumeBlend",1);
            yatay = true;
        }
        else if(other.gameObject.tag == "top")
        {
            Vector3 startingPos = transform.position;
            rb.gravityScale = -1;
            direction = Vector3.right;
            rotation = Quaternion.Euler(0, 0, 180);
            animator.SetFloat("yurumeBlend",1);
            yatay = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "left")
        {
            contactObject.x = collision.transform.position.x;
            contactObject.y = transform.position.y;
            distanceX = 0.024f;
        }
        else if(collision.gameObject.tag == "right")
        {
            contactObject.x = collision.transform.position.x;
            contactObject.y = transform.position.y;
            distanceX = -0.024f;
        }
        else if(collision.gameObject.tag == "bottom")
        {
            contactObject.y = collision.transform.position.y;
            contactObject.x = transform.position.x;
            distanceY = 0.05f;
        }
        else if(collision.gameObject.tag == "top")
        {
            contactObject.y = collision.transform.position.y;
            contactObject.x = transform.position.x;
            distanceY = -0.05f;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "right" || other.gameObject.tag == "left")
        {

        }
    }

    
}
