using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGround;
    
    public bool IsGrounded()
    {
        var position = transform.position;
        
        Debug.DrawRay(position, Vector2.down, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, Vector2.down, 1.1f, whatIsGround);
        return hit.collider != null;
    }
}
