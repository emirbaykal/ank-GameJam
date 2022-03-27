using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    public TavanController tavancollider;


    float verticalDirection;
    private float _horizontalDirection;

    public LayerMask wallLayer;
    private bool _facingRight = true;
    public float wallRayCastLength;

    public bool onWall;
    public bool _onRightWall;

    public float  maxMoveSpeed;

    [SerializeField] private float _movementAcceleration = 70f;

    float wallRunModifier = 0.85f;

    bool wallRun => onWall && verticalDirection > 0f;


    public Rigidbody2D _rb;

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_horizontalDirection, 0f) * _movementAcceleration);

        if (Mathf.Abs(_rb.velocity.x) > maxMoveSpeed)
            _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * maxMoveSpeed, _rb.velocity.y);
        CollisionDetect();
        _rb = GetComponent<Rigidbody2D>();
        if (wallRun) WallRun();
        
    }
   
    void StickToWall()
    {
        //Push player torwards wall
        if (_onRightWall && _horizontalDirection >= 0f)
        {
            _rb.velocity = new Vector2(1f, _rb.velocity.y);
        }
        else if (!_onRightWall && _horizontalDirection <= 0f)
        {
            _rb.velocity = new Vector2(-1f, _rb.velocity.y);
        }

        //Face correct direction
        if (_onRightWall && !_facingRight)
        {
            Flip();
        }
        else if (!_onRightWall && _facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void WallRun()
    {

      
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, verticalDirection * maxMoveSpeed * wallRunModifier);
        
        
    }

    void Tavan()
    {
        if(tavancollider.tavandayim == true)
        {

            _rb.gravityScale = -1;
        }
        else
        {
            _rb.gravityScale = 1;
        }


    }
    void CollisionDetect()
    {

        onWall = Physics2D.Raycast(transform.position, Vector2.right, wallRayCastLength, wallLayer) ||
            Physics2D.Raycast(transform.position, Vector2.left, wallRayCastLength, wallLayer) || 
            Physics2D.Raycast(transform.position, Vector2.up, wallRayCastLength, wallLayer)
            ;

        _onRightWall = Physics2D.Raycast(transform.position, Vector2.right, wallRayCastLength, wallLayer);


        //wall check
       // Gizmos.DrawLine(transform.position, transform.position + Vector3.right * wallRayCastLength);
       // Gizmos.DrawLine(transform.position, transform.position + Vector3.left * wallRayCastLength);

    }
    void Start()
    {

    }

    void tavandadeilsem()
    {


        if (onWall == true)
        {
            tavancollider.tavandayim = false;
        }
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    // Update is called once per frame
    void Update()
    {
        
        _horizontalDirection = GetInput().x;
        verticalDirection = GetInput().y;

        Tavan();
        //tavandadeilsem();
    }
}
