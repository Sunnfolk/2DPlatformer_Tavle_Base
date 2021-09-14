using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Private Variables")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float downSpeed = 4f;
    [SerializeField] private float maxVelocity = -24f;
    
    /* COMPONENTS */
    private PlayerInput _Input;
    private Rigidbody2D _Rigidbody2D;

    /* LONG JUMPING */
    private bool isJumping = false;
    private float jumpTimeCounter;
    private float jumpTime = 0.25f;
    
    /*COYOTE TIME*/
    [SerializeField] private float coyoteTime = 0.5f;
    private float coyoteTimeCounter;
    private bool canCoyote;

    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LongJump();
        DownDash();
        SetMaxVelocity();


        CoyoteTime();

        if (_Input.jump)
        {
            Jump();
        }
    }
    
    private void FixedUpdate()
    {
        _Rigidbody2D.velocity = 
            new Vector2(_Input.moveVector.x * moveSpeed, _Rigidbody2D.velocity.y);
    }


    private void Jump()
    {
        if (!canCoyote) return;
        isJumping = true;
        jumpTimeCounter = jumpTime;
        _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, jumpForce);
    }

   

    private void CoyoteTime()
    {
        if (IsGrounded())
        {
            canCoyote = true;
            coyoteTimeCounter = coyoteTime;
        }
        else if (_Rigidbody2D.velocity.y <= 0)
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        else
        {
            canCoyote = false;
        }

        if (coyoteTimeCounter < 0)
        {
            canCoyote = false;
        }
    }

    private void LongJump()
    {
        if (_Input.longJump && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                _Rigidbody2D.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (!_Input.longJump)
        {
            isJumping = false;
        }
    }
    
  
    private void DownDash()
    {
        if (_Input.downDash)
        {
            _Rigidbody2D.AddForce(Vector2.down * downSpeed, ForceMode2D.Impulse);
        }
    }

    private void SetMaxVelocity()
    {
        if (IsGrounded()) return;
        if (_Rigidbody2D.velocity.y < maxVelocity)
        {
            _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, maxVelocity);
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down, new Color(1f, 0f, 1f));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, whatIsGround);
        return hit.collider != null;
    }
}