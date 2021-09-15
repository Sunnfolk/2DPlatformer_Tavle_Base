using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _input;
    private PlayerMovement _movement;
    private PlayerCollision _collision;
    private Rigidbody2D _rigidbody2D;

    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Fall = Animator.StringToHash("Fall");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
        _collision = GetComponent<PlayerCollision>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_input.moveVector.x != 0)
        {
            transform.localScale = new Vector2(_input.moveVector.x * 1f, 1f);
        }
        
        if (_collision.IsGrounded())
        {
            _animator.Play(_input.moveVector.x != 0 ? Run : Idle);
        }
        else
        {
            _animator.Play(_rigidbody2D.velocity.y > 0 ? Jump : Fall);
        }
    }
}