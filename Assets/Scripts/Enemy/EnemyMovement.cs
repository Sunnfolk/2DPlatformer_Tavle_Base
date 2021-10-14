using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool goingRight;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _Rigidbody2D;
    private PlayerCollision _Collision;
    [SerializeField] private LayerMask whatIsGround;

    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Collision = GetComponent<PlayerCollision>();
    }

    private void Update()
    {
        if (NoLedges() && !Wall())
        {
            var vel = _Rigidbody2D.velocity;
            var spd = goingRight ? new Vector2(moveSpeed, vel.y) : new Vector2(-moveSpeed, vel.y);

            _Rigidbody2D.velocity = spd;
        }
        else goingRight = !goingRight;
    }
    
    //Check if there is ground for the enemy to walk on in current direction
    private bool NoLedges()
    {
        var vec = goingRight ? new Vector3(0.5f, 0f, 0f) : new Vector3(-0.5f, 0f, 0f);
        var pos = transform.position + vec;
        
        //Debug.DrawRay(pos, Vector2.down, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(pos, Vector2.down, 0.6f, whatIsGround);

        return hit.collider != null;
    }

    //Check if there is ground/wall in front of the enemy in current direction
    private bool Wall()
    {
        var vec = goingRight ? Vector2.right : Vector2.left;
        var pos = transform.position;
        
        //Debug.DrawRay(pos, vec, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(pos, vec, 0.5f, whatIsGround);

        return hit.collider != null;
    }
}
