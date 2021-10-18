using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    #region VARIABLES
        private Animator _animator;
        private PlayerInput _input;
        private PlayerMovement _movement;
            // only if you have this script
            private PlayerCollision _collision;
        private Rigidbody2D _rigidbody2D;

        private float timerCount;
        public float timer;
        private bool canCount;
    #endregion

    public string test = "NO_Hello";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
            _collision = GetComponent<PlayerCollision>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movement = GetComponent<PlayerMovement>();
        
        //TODO: Use this code to set up a Save system and eliminate all Object Save Files in Player PRefs
        print(test.StartsWith("NO") ? "Starts with NO" : "Does not Start with NO");

    }
    
    private void Update()
    {
        print(test.StartsWith("NO") ? "Starts with NO" : "Does not Start with NO");

        if (_input.moveVector.x != 0)
        {
            transform.localScale = new Vector2(_input.moveVector.x, 1f);
        }
        
        if (_collision.IsGrounded())
        {
            if (_input.moveVector.x != 0)
            {
                _animator.Play("Run");
            }
            else
            {
                _animator.Play("Idle");
            }
        }
        else
        {
            if (_rigidbody2D.velocity.y > 0)
            {
                _animator.Play("Jump");
            }
            else
            {
                _animator.Play("Fall");
            }
        }
    }

    private void AnimationTimer()
    {
        timer = _animator.GetCurrentAnimatorStateInfo(0).length;

        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
    }
}