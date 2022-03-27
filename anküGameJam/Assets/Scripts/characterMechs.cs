using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterMechs : MonoBehaviour
{
    public BoxCollider2D boxcol,dokscol;
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
    public float movY;
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
        movY=Input.GetAxis("Vertical");
        if (yatay == true)
        {
            transform.Translate(direction * Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed);
            movY = 0;
        }
        else
        {
            transform.Translate(direction * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
            movX = 0;
        }
        if (movX != 0 || movY != 0)
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
            spriteRenderer.flipY = false;
            Vector3 startingPos = transform.position;
            direction = Vector3.up;
            rb.gravityScale = 1;
            rotation = Quaternion.Euler(0, 0, -90);
            animator.SetFloat("yurumeBlend",1);
            animator.SetFloat("idleBlend",1);
            yatay = false;
            animator.SetTrigger("reverseicKose");
            rb.drag = 50;
        
        }
        else if(other.gameObject.tag == "right")
        {
            //GetComponent<BoxCollider2D>().offset = new Vector2(0.06391939f,GetComponent<BoxCollider2D>().offset.y);
            spriteRenderer.flipY = false;
            animator.SetTrigger("icKose");
            Debug.Log("asd");
            Vector3 startingPos = transform.position;
            direction = Vector3.up;
            rb.gravityScale = 1;
            rotation = Quaternion.Euler(0, 0, 90);
            animator.SetFloat("yurumeBlend",1);
            yatay = false;
            animator.SetFloat("idleBlend",1);
            rb.drag = 50;
        }
        else if(other.gameObject.tag == "bottom")
        {
            spriteRenderer.flipY = false;
            Vector3 startingPos = transform.position;
            direction = Vector3.right;
            rotation = Quaternion.Euler(0, 0, 0);
            animator.SetFloat("yurumeBlend",0);
            yatay = true;
            animator.SetFloat("idleBlend",0);
        }
        else if(other.gameObject.tag == "top")
        {
            Vector3 startingPos = transform.position;
            rb.gravityScale = -1;
            direction = Vector3.right;
            rotation = Quaternion.Euler(0, 0, 180);
            animator.SetFloat("yurumeBlend",0);
            yatay = true;
            animator.SetFloat("idleBlend",0);
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
            rb.drag = 0;
        }
    }

    public void doksanDonme()
    {
        boxcol.enabled = false;
        dokscol.enabled = true;
    }
    public void duz()
    {
        boxcol.enabled = true;
        dokscol.enabled = false;
    }
}
