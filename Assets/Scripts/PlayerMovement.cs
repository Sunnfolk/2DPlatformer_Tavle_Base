using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [Header("Private Variables")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float downSpeed = 35f;
    [SerializeField] private float maxVelocity = -24f;
    
    /* COMPONENTS */
    private PlayerInput _input;
    private PlayerCollision _collision;
    private Rigidbody2D _rigidbody2D;

    /* LONG JUMPING */
    private bool _isJumping = false;
    private float _jumpTimeCounter;
    private float jumpTime = 0.25f;
    
    /*COYOTE TIME*/
    [SerializeField] private float coyoteTime = 0.3f;
    private float _coyoteTimeCounter;
    [HideInInspector] public bool canCoyote;
    #endregion
   
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _collision = GetComponent<PlayerCollision>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = 
            new Vector2(_input.moveVector.x * moveSpeed, _rigidbody2D.velocity.y);
    }
    
    private void Update()
    {
        SlopeController();

        LongJump();
        DownDash();
        Coyote();
        
        SetMaxVelocity();
        
        Jump();
    }

    private void Jump()
    {
        if (_input.jump)
        {
            if (!canCoyote) return;
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }
    }
    
    private void LongJump()
    {
        if (_input.longJump && _isJumping)
        {
            if (_jumpTimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (!_input.longJump)
        {
            _isJumping = false;
        }
    }
    
    
    private void DownDash()
    {
        if (_input.downDash)
        {
            _rigidbody2D.AddForce(Vector2.down * downSpeed, ForceMode2D.Impulse);
        }
    }

    private void SetMaxVelocity()
    {
        if (_collision.IsGrounded()) return;
        if (_rigidbody2D.velocity.y < maxVelocity)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, maxVelocity);
        }
    }

    private void Coyote()
    {
        if (_collision.IsGrounded())
        {
            canCoyote = true;
            _coyoteTimeCounter = coyoteTime;
        }
        else if (_rigidbody2D.velocity.y <= 0)
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }
        else
        {
            canCoyote = false;
        }

        if (_coyoteTimeCounter < 0)
        {
            canCoyote = false;
        }
    }
    
    private void SlopeController()
    {
        if ((_input.moveVector.x == 0 && _input.moveVector.y == 0) && _collision.IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(0f, 0f);
            _rigidbody2D.gravityScale = 0f;
        }
        else
        {
            _rigidbody2D.gravityScale = 3f;
        }
    }
}